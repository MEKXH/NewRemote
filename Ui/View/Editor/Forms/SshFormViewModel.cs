using _1RM.Model.Protocol;
using _1RM.View.Editor.Forms.Advanced;

namespace _1RM.View.Editor.Forms
{
    public class SshFormViewModel : ProtocolBaseWithAddressPortUserPwdFormViewModel
    {
        public new SSH New { get; }
        public SshAdvancedSettingsViewModel AdvancedSettingsViewModel { get; }

        public SshFormViewModel(SSH protocolBase) : base(protocolBase)
        {
            New = protocolBase;
            AdvancedSettingsViewModel = new SshAdvancedSettingsViewModel(protocolBase);
        }
    }
}
