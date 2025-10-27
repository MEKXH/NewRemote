using _1RM.Model.Protocol;
using _1RM.View.Editor.Forms;
using Shawn.Utils;

namespace _1RM.View.Editor.Forms.Advanced
{
    public class TelnetAdvancedSettingsViewModel : NotifyPropertyChangedBase
    {
        private readonly Telnet _telnet;

        public TelnetAdvancedSettingsViewModel(Telnet telnet)
        {
            _telnet = telnet;
        }

        public Telnet New => _telnet;
    }
}