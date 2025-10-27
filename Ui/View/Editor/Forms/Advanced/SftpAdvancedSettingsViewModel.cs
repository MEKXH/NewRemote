using _1RM.Model.Protocol;
using _1RM.View.Editor.Forms;
using Shawn.Utils;

namespace _1RM.View.Editor.Forms.Advanced
{
    public class SftpAdvancedSettingsViewModel : NotifyPropertyChangedBase
    {
        private readonly SFTP _sftp;

        public SftpAdvancedSettingsViewModel(SFTP sftp)
        {
            _sftp = sftp;
        }

        public SFTP New => _sftp;
    }
}