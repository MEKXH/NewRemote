using _1RM.Model.Protocol;
using _1RM.View.Editor.Forms.Advanced;

namespace _1RM.View.Editor.Forms
{
    public class TelnetFormViewModel : ProtocolBaseWithAddressPortFormViewModel
    {
        public new Telnet New { get; }
        public TelnetAdvancedSettingsViewModel AdvancedSettingsViewModel { get; }

        public TelnetFormViewModel(Telnet protocolBase) : base(protocolBase)
        {
            New = protocolBase;
            AdvancedSettingsViewModel = new TelnetAdvancedSettingsViewModel(protocolBase);
        }
    }
}
