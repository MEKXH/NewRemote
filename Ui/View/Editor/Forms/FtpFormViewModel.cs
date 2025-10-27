using _1RM.Model.Protocol;
using _1RM.View.Editor.Forms.Advanced;

namespace _1RM.View.Editor.Forms
{
    public class FtpFormViewModel : ProtocolBaseWithAddressPortUserPwdFormViewModel
    {
        public new FTP New { get; }
        public FtpAdvancedSettingsViewModel AdvancedSettingsViewModel { get; }

        public FtpFormViewModel(FTP protocolBase) : base(protocolBase)
        {
            New = protocolBase;
            AdvancedSettingsViewModel = new FtpAdvancedSettingsViewModel(protocolBase);
        }
    }
}
