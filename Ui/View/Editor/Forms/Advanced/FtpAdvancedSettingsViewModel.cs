using _1RM.Model.Protocol;
using _1RM.View.Editor.Forms;
using Shawn.Utils;

namespace _1RM.View.Editor.Forms.Advanced
{
    public class FtpAdvancedSettingsViewModel : NotifyPropertyChangedBase
    {
        private readonly FTP _ftp;

        public FtpAdvancedSettingsViewModel(FTP ftp)
        {
            _ftp = ftp;
        }

        public FTP New => _ftp;
    }
}