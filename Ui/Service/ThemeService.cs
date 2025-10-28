using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Shawn.Utils.Wpf;

namespace _1RM.Service
{
    public class ThemeService
    {
        private readonly ResourceDictionary _appResourceDictionary;
        public ThemeConfig CurrentTheme;
        public Dictionary<string, ThemeConfig> Themes { get; } = new Dictionary<string, ThemeConfig>();
        public ThemeService(ResourceDictionary appResourceDictionary, ThemeConfig defaultTheme)
        {
            _appResourceDictionary = appResourceDictionary;
            Themes.Add("Light", new ThemeConfig()
            {
                ThemeName = "Light",
                PrimaryMidColor = "#FFF2F3F5",
                PrimaryLightColor = "#FFFFFFFF",
                PrimaryDarkColor = "#FFE4E7EB",
                PrimaryTextColor = "#FF232323",
                AccentMidColor = "#FFE83D61",
                AccentLightColor = "#FFED6884",
                AccentDarkColor = "#FFB5304C",
                AccentTextColor = "#FFFFFFFF",
                BackgroundColor = "#FFFFFFFF",
                BackgroundTextColor = "#000000",
            });
            Themes.Add("Dark", new ThemeConfig()
            {
                ThemeName = "Dark",
                PrimaryMidColor = "#323233",
                PrimaryLightColor = "#474748",
                PrimaryDarkColor = "#2d2d2d",
                PrimaryTextColor = "#cccccc",
                AccentMidColor = "#FF007ACC",
                AccentLightColor = "#FF32A7F4",
                AccentDarkColor = "#FF0061A3",
                AccentTextColor = "#FFFFFFFF",
                BackgroundColor = "#1e1e1e",
                BackgroundTextColor = "#cccccc",
            });
            // 新增的主题放在这里
            Themes.Add("Dracula", new ThemeConfig()
            {
                ThemeName = "Dracula",
                PrimaryMidColor = "#282a36",
                PrimaryLightColor = "#44475a",
                PrimaryDarkColor = "#21222c",
                PrimaryTextColor = "#f8f8f2",
                AccentMidColor = "#bd93f9",
                AccentLightColor = "#d6acff",
                AccentDarkColor = "#9f7aea",
                AccentTextColor = "#ffffff",
                BackgroundColor = "#1e1f29",
                BackgroundTextColor = "#f8f8f2",
            });
            Themes.Add("OneDarkPro", new ThemeConfig()
            {
                ThemeName = "OneDarkPro",
                PrimaryMidColor = "#2c313c",
                PrimaryLightColor = "#3e4451",
                PrimaryDarkColor = "#21252b",
                PrimaryTextColor = "#abb2bf",
                AccentMidColor = "#61afef",
                AccentLightColor = "#8fc6f5",
                AccentDarkColor = "#4d8fcc",
                AccentTextColor = "#ffffff",
                BackgroundColor = "#1e1f23",
                BackgroundTextColor = "#abb2bf",
            });
            Themes.Add("VSCode", new ThemeConfig()
            {
                ThemeName = "VSCode",
                PrimaryMidColor = "#252526",
                PrimaryLightColor = "#2d2d30",
                PrimaryDarkColor = "#1e1e1e",
                PrimaryTextColor = "#cccccc",
                AccentMidColor = "#0078d4",
                AccentLightColor = "#409cff",
                AccentDarkColor = "#005a9e",
                AccentTextColor = "#ffffff",
                BackgroundColor = "#1e1e1e",
                BackgroundTextColor = "#cccccc",
            });
            Themes.Add("MaterialDark", new ThemeConfig()
            {
                ThemeName = "MaterialDark",
                PrimaryMidColor = "#2d3748",
                PrimaryLightColor = "#4a5568",
                PrimaryDarkColor = "#1a202c",
                PrimaryTextColor = "#e2e8f0",
                AccentMidColor = "#805ad5",
                AccentLightColor = "#9f7aea",
                AccentDarkColor = "#6b46c1",
                AccentTextColor = "#ffffff",
                BackgroundColor = "#171923",
                BackgroundTextColor = "#e2e8f0",
            });
            Themes.Add("GitHub", new ThemeConfig()
            {
                ThemeName = "GitHub",
                PrimaryMidColor = "#f6f8fa",
                PrimaryLightColor = "#ffffff",
                PrimaryDarkColor = "#d1d9e0",
                PrimaryTextColor = "#24292e",
                AccentMidColor = "#0366d6",
                AccentLightColor = "#54a3ff",
                AccentDarkColor = "#0256cc",
                AccentTextColor = "#ffffff",
                BackgroundColor = "#ffffff",
                BackgroundTextColor = "#24292e",
            });
            Themes.Add("SolarizedLight", new ThemeConfig()
            {
                ThemeName = "SolarizedLight",
                PrimaryMidColor = "#fdf6e3",
                PrimaryLightColor = "#ffffff",
                PrimaryDarkColor = "#eee8d5",
                PrimaryTextColor = "#657b83",
                AccentMidColor = "#b58900",
                AccentLightColor = "#d7a740",
                AccentDarkColor = "#8b6f00",
                AccentTextColor = "#ffffff",
                BackgroundColor = "#fdf6e3",
                BackgroundTextColor = "#657b83",
            });
            Themes.Add("Nord", new ThemeConfig()
            {
                ThemeName = "Nord",
                PrimaryMidColor = "#3b4252",
                PrimaryLightColor = "#434c5e",
                PrimaryDarkColor = "#2e3440",
                PrimaryTextColor = "#d8dee9",
                AccentMidColor = "#88c0d0",
                AccentLightColor = "#a3c8d8",
                AccentDarkColor = "#6ba3b3",
                AccentTextColor = "#ffffff",
                BackgroundColor = "#242933",
                BackgroundTextColor = "#d8dee9",
            });
            Themes.Add("Monokai", new ThemeConfig()
            {
                ThemeName = "Monokai",
                PrimaryMidColor = "#272822",
                PrimaryLightColor = "#3e3d32",
                PrimaryDarkColor = "#1e1f1c",
                PrimaryTextColor = "#f8f8f2",
                AccentMidColor = "#f92672",
                AccentLightColor = "#fc5fb6",
                AccentDarkColor = "#c71e5a",
                AccentTextColor = "#ffffff",
                BackgroundColor = "#1e1f1c",
                BackgroundTextColor = "#f8f8f2",
            });
            Themes.Add("AtomOneLight", new ThemeConfig()
            {
                ThemeName = "AtomOneLight",
                PrimaryMidColor = "#fafafa",
                PrimaryLightColor = "#ffffff",
                PrimaryDarkColor = "#e0e0e0",
                PrimaryTextColor = "#2d3142",
                AccentMidColor = "#0184ff",
                AccentLightColor = "#4ca2ff",
                AccentDarkColor = "#0066cc",
                AccentTextColor = "#ffffff",
                BackgroundColor = "#ffffff",
                BackgroundTextColor = "#2d3142",
            });
            Themes.Add("Gruvbox", new ThemeConfig()
            {
                ThemeName = "Gruvbox",
                PrimaryMidColor = "#3c3836",
                PrimaryLightColor = "#504945",
                PrimaryDarkColor = "#282828",
                PrimaryTextColor = "#ebdbb2",
                AccentMidColor = "#d79921",
                AccentLightColor = "#fabd2f",
                AccentDarkColor = "#b58900",
                AccentTextColor = "#000000",
                BackgroundColor = "#1d2021",
                BackgroundTextColor = "#ebdbb2",
            });
            Themes.Add("Catppuccin", new ThemeConfig()
            {
                ThemeName = "Catppuccin",
                PrimaryMidColor = "#302d41",
                PrimaryLightColor = "#413f58",
                PrimaryDarkColor = "#1e1e2e",
                PrimaryTextColor = "#cdd6f4",
                AccentMidColor = "#cba6f7",
                AccentLightColor = "#dcbdf7",
                AccentDarkColor = "#a687d4",
                AccentTextColor = "#ffffff",
                BackgroundColor = "#1e1e2e",
                BackgroundTextColor = "#cdd6f4",
            });
            // 原有的主题
            Themes.Add("PRemoteM", new ThemeConfig()
            {
                ThemeName = "PRemoteM",
                PrimaryMidColor = "#102b3e",
                PrimaryLightColor = "#445a68",
                PrimaryDarkColor = "#0c2230",
                PrimaryTextColor = "#FFFFFFFF",
                AccentMidColor = "#FFE83D61",
                AccentLightColor = "#FFED6884",
                AccentDarkColor = "#FFB5304C",
                AccentTextColor = "#FFFFFFFF",
                BackgroundColor = "#ced8e1",
                BackgroundTextColor = "#000000",
            });
            Themes.Add("SecretKey", new ThemeConfig()
            {
                ThemeName = "Light",
                PrimaryMidColor = "#FF473368",
                PrimaryLightColor = "#796090",
                PrimaryDarkColor = "#382853",
                PrimaryTextColor = "#FFFFFFFF",
                AccentMidColor = "#FFEF6D3B",
                AccentLightColor = "#FF9A63",
                AccentDarkColor = "#BF572F",
                AccentTextColor = "#FFFFFFFF",
                BackgroundColor = "#FFF2F1EC",
                BackgroundTextColor = "#000000",
            });
            Themes.Add("Greystone", new ThemeConfig()
            {
                ThemeName = "Greystone",
                PrimaryMidColor = "#FFC7D0D5",
                PrimaryLightColor = "#F9FDFD",
                PrimaryDarkColor = "#9FA6AA",
                PrimaryTextColor = "#FF1B2C3F",
                AccentMidColor = "#FFFF7247",
                AccentLightColor = "#FFED583A",
                AccentDarkColor = "#CC5B38",
                AccentTextColor = "#FFFFFFFF",
                BackgroundColor = "#FFF5F5F5",
                BackgroundTextColor = "#000000",
            });
            Themes.Add("Asphalt", new ThemeConfig()
            {
                ThemeName = "Asphalt",
                PrimaryMidColor = "#FF393939",
                PrimaryLightColor = "#6B6661",
                PrimaryDarkColor = "#2D2D2D",
                PrimaryTextColor = "#FFFFFFFF",
                AccentMidColor = "#FFFF7247",
                AccentLightColor = "#FFED583A",
                AccentDarkColor = "#CC5B38",
                AccentTextColor = "#FFFFFFFF",
                BackgroundColor = "#FFF5F5F5",
                BackgroundTextColor = "#000000",
            });

            CurrentTheme = defaultTheme;
            ApplyTheme(defaultTheme);
        }

        public void ApplyTheme(ThemeConfig theme)
        {
            const string resourceTypeKey = "__Resource_Type_Key";
            const string resourceTypeValue = "__Resource_Type_Value=theme";
            void SetKey(IDictionary rd, string key, object value)
            {
                if (!rd.Contains(key))
                    rd.Add(key, value);
                else
                    rd[key] = value;
            }

            // create new theme resources
            var rd = new ResourceDictionary();
            SetKey(rd, resourceTypeKey, resourceTypeValue);
            SetKey(rd, "PrimaryMidColor", ColorAndBrushHelper.HexColorToMediaColor(theme.PrimaryMidColor));
            SetKey(rd, "PrimaryLightColor", ColorAndBrushHelper.HexColorToMediaColor(theme.PrimaryLightColor));
            SetKey(rd, "PrimaryDarkColor", ColorAndBrushHelper.HexColorToMediaColor(theme.PrimaryDarkColor));
            SetKey(rd, "PrimaryTextColor", ColorAndBrushHelper.HexColorToMediaColor(theme.PrimaryTextColor));
            SetKey(rd, "AccentMidColor", ColorAndBrushHelper.HexColorToMediaColor(theme.AccentMidColor));
            SetKey(rd, "AccentLightColor", ColorAndBrushHelper.HexColorToMediaColor(theme.AccentLightColor));
            SetKey(rd, "AccentDarkColor", ColorAndBrushHelper.HexColorToMediaColor(theme.AccentDarkColor));
            SetKey(rd, "AccentTextColor", ColorAndBrushHelper.HexColorToMediaColor(theme.AccentTextColor));
            SetKey(rd, "BackgroundColor", ColorAndBrushHelper.HexColorToMediaColor(theme.BackgroundColor));
            SetKey(rd, "BackgroundTextColor", ColorAndBrushHelper.HexColorToMediaColor(theme.BackgroundTextColor));


            SetKey(rd, "PrimaryMidBrush", ColorAndBrushHelper.ColorToMediaBrush(theme.PrimaryMidColor));
            SetKey(rd, "PrimaryLightBrush", ColorAndBrushHelper.ColorToMediaBrush(theme.PrimaryLightColor));
            SetKey(rd, "PrimaryDarkBrush", ColorAndBrushHelper.ColorToMediaBrush(theme.PrimaryDarkColor));
            SetKey(rd, "PrimaryTextBrush", ColorAndBrushHelper.ColorToMediaBrush(theme.PrimaryTextColor));
            SetKey(rd, "AccentMidBrush", ColorAndBrushHelper.ColorToMediaBrush(theme.AccentMidColor));
            SetKey(rd, "AccentLightBrush", ColorAndBrushHelper.ColorToMediaBrush(theme.AccentLightColor));
            SetKey(rd, "AccentDarkBrush", ColorAndBrushHelper.ColorToMediaBrush(theme.AccentLightColor));
            SetKey(rd, "AccentTextBrush", ColorAndBrushHelper.ColorToMediaBrush(theme.AccentTextColor));
            SetKey(rd, "BackgroundBrush", ColorAndBrushHelper.ColorToMediaBrush(theme.BackgroundColor));
            SetKey(rd, "BackgroundTextBrush", ColorAndBrushHelper.ColorToMediaBrush(theme.BackgroundTextColor));

            SetKey(rd, "PrimaryColor", ColorAndBrushHelper.HexColorToMediaColor(theme.AccentMidColor));
            SetKey(rd, "DarkPrimaryColor", ColorAndBrushHelper.HexColorToMediaColor(theme.AccentDarkColor));
            SetKey(rd, "PrimaryDarkColor", ColorAndBrushHelper.HexColorToMediaColor(theme.AccentTextColor));

            var font = GetFontFamily(theme.FontFamily);
            SetKey(rd, "GlobalFontFamily", font);
            theme.FontSize = Math.Max(10, theme.FontSize);
            double globalFontSizeSmall = Math.Min(20.0, theme.FontSize - 2.0);
            double globalFontSizeBody = Math.Min(20.0, theme.FontSize);
            double globalFontSizeSubtitle = Math.Min(20.0, theme.FontSize + 2.0);
            double globalFontSizeTitle = Math.Min(20.0, theme.FontSize + 6.0);
            SetKey(rd, "GlobalFontSizeTitle", globalFontSizeTitle);
            SetKey(rd, "GlobalFontSizeSubtitle", globalFontSizeSubtitle);
            SetKey(rd, "GlobalFontSizeBody", globalFontSizeBody);
            SetKey(rd, "GlobalFontSizeSmall", globalFontSizeSmall);





            // remove old theme resources
            var rs = _appResourceDictionary.MergedDictionaries.Where(o =>
                (o?.Source?.IsAbsoluteUri == true && o.Source.AbsolutePath.ToLower().IndexOf("Default.xaml", StringComparison.OrdinalIgnoreCase) >= 0)
                || o?[resourceTypeKey]?.ToString() == resourceTypeValue).ToArray();
            foreach (var r in rs)
            {
                _appResourceDictionary.MergedDictionaries.Remove(r);
            }

            // add new theme resources
            _appResourceDictionary.MergedDictionaries.Add(rd);
        }

        private static FontFamily GetFontFamily(string name)
        {
            // set default font family
            var fontFamily = Fonts.SystemFontFamilies.FirstOrDefault(x => string.Equals(x.Source, name, StringComparison.CurrentCultureIgnoreCase));
            fontFamily ??= Fonts.SystemFontFamilies.FirstOrDefault(x => string.Equals(x.Source, "Microsoft YaHei", StringComparison.CurrentCultureIgnoreCase));
            fontFamily ??= Fonts.SystemFontFamilies.FirstOrDefault(x => x.Source.EndsWith("YaHei", StringComparison.OrdinalIgnoreCase));
            fontFamily ??= Fonts.SystemFontFamilies.FirstOrDefault(x => x.Source.IndexOf("YaHei", StringComparison.OrdinalIgnoreCase) >= 0);
            fontFamily ??= Fonts.SystemFontFamilies.FirstOrDefault(x => x.Source.IndexOf("雅黑", StringComparison.OrdinalIgnoreCase) >= 0);
            fontFamily ??= Fonts.SystemFontFamilies.FirstOrDefault(x => x.Source.IndexOf("雅黑", StringComparison.OrdinalIgnoreCase) >= 0);

            return fontFamily ?? Fonts.SystemFontFamilies.First();
        }
    }
}
