using _1RM.Model.Protocol;
using _1RM.Model.Protocol.Base;
using _1RM.View.Editor.Forms.Advanced;
using Newtonsoft.Json;

namespace _1RM.View.Editor.Forms
{
    public class RdpFormViewModel : ProtocolBaseWithAddressPortUserPwdFormViewModel
    {
        public new RDP New { get; }
        public RdpAdvancedSettingsViewModel AdvancedSettingsViewModel { get; }

        public RdpFormViewModel(RDP protocolBase) : base(protocolBase)
        {
            New = protocolBase;
            AdvancedSettingsViewModel = new RdpAdvancedSettingsViewModel(protocolBase);
        }
    }
}
