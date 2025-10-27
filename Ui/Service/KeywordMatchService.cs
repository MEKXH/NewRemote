using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Shawn.Utils;
using Shawn.Utils.Interface;
using VariableKeywordMatcher.Model;
using VariableKeywordMatcher.Provider.ChineseZhCnPinYin;
using VariableKeywordMatcher.Provider.ChineseZhCnPinYinInitials;
using VariableKeywordMatcher.Provider.DirectMatch;
using VariableKeywordMatcher.Provider.DiscreteMatch;
using VariableKeywordMatcher.Provider.InitialsMatch;

namespace _1RM.Service
{
    public class MatchProviderInfo : NotifyPropertyChangedBase
    {

        private string _name = "";
        public string Name
        {
            get => _name;
            set => SetAndNotifyIfChanged(ref _name, value);
        }


        private string _title1 = "";
        public string Title1
        {
            get => _title1;
            set => SetAndNotifyIfChanged(ref _title1, value);
        }



        private string _title2 = "";
        public string Title2
        {
            get => _title2;
            set => SetAndNotifyIfChanged(ref _title2, value);
        }


        private bool _enabled = true;
        public bool Enabled
        {
            get => _enabled;
            set => SetAndNotifyIfChanged(ref _enabled, value);
        }

        private bool _isEditable = true;
        public bool IsEditable
        {
            get => _isEditable;
            set => SetAndNotifyIfChanged(ref _isEditable, value);
        }
    }

    public class KeywordMatchService
    {
        public class Cache
        {
            public Cache(MatchCache matchCache)
            {
                _matchCache = matchCache;
                _accessTime = DateTime.Now;
            }

            private DateTime _accessTime;
            private MatchCache _matchCache;

            public ref MatchCache GetMatchCache()
            {
                _accessTime = DateTime.Now;
                return ref _matchCache;
            }

            public DateTime GetAccessTime() => _accessTime;
        }

        /// <summary>
        /// this is the cache for the raw string to speed up match, for example, a english srint "Abc Def" will be cached as {"abc def", "ad"} a Chinese name will be cache as PinYin.
        /// </summary>
        private readonly Dictionary<string, Cache> _matchCaches = new Dictionary<string, Cache>(500);

        private VariableKeywordMatcher.Matcher _matcher;

        public KeywordMatchService()
        {
            _matcher = VariableKeywordMatcherIn1.Builder.Build(new string[]
            {
                DirectMatchProvider.GetName(),
                DiscreteMatchProvider.GetName(),
            }, false);
        }


        public void Init(string[] providerNames)
        {
            Debug.Assert(providerNames.Length > 0);
            _matcher = VariableKeywordMatcherIn1.Builder.Build(providerNames, false);
            _matchCaches.Clear();
        }

        private void CleanUp()
        {
            lock (this)
            {
                if (_matchCaches.Any(x => x.Value.GetAccessTime() < DateTime.Now.AddHours(-24)))
                {
                    var kvs = _matchCaches.Where(x => x.Value.GetAccessTime() < DateTime.Now.AddHours(-12))?
                        .OrderBy(x => x.Value.GetAccessTime())?.ToArray();
                    if (kvs!= null)
                    {
                        foreach (var kv in kvs)
                        {
                            _matchCaches.Remove(kv.Key);
                        }
                    }
                } 
            }
        }

        //public MatchResult Match(string originalString, List<string> keywords)
        //{
        //    CleanUp();
        //    var cache = GetCache(originalString);
        //    return _matcher.Match(cache, keywords);
        //}

        //public MatchResult Match(string originalString, string keyword)
        //{
        //    CleanUp();
        //    var cache = GetCache(originalString);
        //    return _matcher.Match(cache, new[] { keyword });
        //}

        public MatchResults Match(List<string> originalStrings, IEnumerable<string> keywords)
        {
            var kws = keywords.ToArray();
            CleanUp();
            var matchCaches = originalStrings.Select(x => GetCache(x)).ToList();
            return _matcher.Matchs(matchCaches, kws, 2);
        }

        private ref MatchCache GetCache(string originalString)
        {
            lock (this)
            {
                if (!_matchCaches.ContainsKey(originalString))
                {
                    var cache = new MatchCache(originalString);
                    _matchCaches.Add(originalString, new Cache(cache));
                } 
                return ref _matchCaches[originalString].GetMatchCache();
            }
        }

        public void UpdateMatchCache(string originalString)
        {
            var newCache = _matcher.CreateStringCache(originalString);
            GetCache(originalString).SpellCaches = newCache.SpellCaches;
        }

        public static List<MatchProviderInfo> GetMatchProviderInfos()
        {
            var providerNames = VariableKeywordMatcherIn1.Builder.GetAvailableProviderNames();
            var matchProviderInfos = new List<MatchProviderInfo>(Enumerable.Count<string>(providerNames));
            var languageService = IoC.Get<ILanguageService>();

            foreach (var enumProviderType in providerNames)
            {
                // Get localized descriptions based on provider name
                var (title1, title2) = GetLocalizedProviderDescriptions(enumProviderType, languageService);

                matchProviderInfos.Add(new MatchProviderInfo()
                {
                    Name = enumProviderType,
                    Title1 = title1,
                    Title2 = title2,
                    Enabled = false,
                });
            }
            // first time init.
            var ci = CultureInfo.CurrentCulture;
            string code = ci.Name.ToLower();
            foreach (var matchProviderInfo in matchProviderInfos)
            {
                matchProviderInfo.Enabled = false;
            }

            var setEnabled = new Action<string, bool, bool>((name, isEnabled, isEditable) =>
            {
                if (matchProviderInfos.Any(x => x.Name == name))
                {
                    matchProviderInfos.First(x => x.Name == name).Enabled = isEnabled;
                    matchProviderInfos.First(x => x.Name == name).IsEditable = isEditable;
                }
            });

            setEnabled(DirectMatchProvider.GetName(), true, false);
            setEnabled(InitialsMatchProvider.GetName(), true, true);
            setEnabled(DiscreteMatchProvider.GetName(), false, true);

            if (code.StartsWith("zh"))
            {
                setEnabled(ChineseZhCnPinYinMatchProvider.GetName(), true, true);
                setEnabled(ChineseZhCnPinYinInitialsMatchProvider.GetName(), true, true);
            }
            return matchProviderInfos;
        }

        private static (string title1, string title2) GetLocalizedProviderDescriptions(string providerName, ILanguageService languageService)
        {
            // Default fallback to library descriptions
            var title1 = VariableKeywordMatcherIn1.Builder.GetProviderDescription(providerName);
            var title2 = VariableKeywordMatcherIn1.Builder.GetProviderDescriptionEn(providerName);

            // Check if language service is available
            if (languageService == null)
            {
                return (title1, title2);
            }

            // Map provider names to localized resource keys
            // Match against actual provider names from the library
            switch (providerName)
            {
                case "DirectMatch":
                    title1 = languageService.Translate("keyword_matcher_direct");
                    title2 = languageService.Translate("keyword_matcher_direct_en");
                    break;
                case "DiscreteMatch":
                    title1 = languageService.Translate("keyword_matcher_discrete");
                    title2 = languageService.Translate("keyword_matcher_discrete_en");
                    break;
                case "InitialsMatch":
                    title1 = languageService.Translate("keyword_matcher_initials");
                    title2 = languageService.Translate("keyword_matcher_initials_en");
                    break;
                case "ChineseZhCnPinYinMatch":
                    title1 = languageService.Translate("keyword_matcher_pinyin");
                    title2 = languageService.Translate("keyword_matcher_pinyin_en");
                    break;
                case "ChineseZhCnPinYinInitialsMatch":
                    title1 = languageService.Translate("keyword_matcher_pinyin_initials");
                    title2 = languageService.Translate("keyword_matcher_pinyin_initials_en");
                    break;
            }

            return (title1, title2);
        }
    }
}
