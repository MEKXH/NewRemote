using _1RM.Model.Protocol;
using _1RM.View.Editor.Forms.Advanced;

namespace _1RM.View.Editor.Forms
{
    public class SftpFormViewModel : ProtocolBaseWithAddressPortUserPwdFormViewModel
    {
        public new SFTP New { get; }
        public SftpAdvancedSettingsViewModel AdvancedSettingsViewModel { get; }

        public SftpFormViewModel(SFTP protocolBase) : base(protocolBase)
        {
            New = protocolBase;
            AdvancedSettingsViewModel = new SftpAdvancedSettingsViewModel(protocolBase);
        }
    }
}
