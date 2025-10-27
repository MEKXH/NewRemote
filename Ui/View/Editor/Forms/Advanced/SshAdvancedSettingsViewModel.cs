using _1RM.Model.Protocol;
using _1RM.View.Editor.Forms;
using Shawn.Utils;
using Shawn.Utils.Wpf.FileSystem;

namespace _1RM.View.Editor.Forms.Advanced
{
    public class SshAdvancedSettingsViewModel : NotifyPropertyChangedBase
    {
        private readonly SSH _ssh;

        public SshAdvancedSettingsViewModel(SSH ssh)
        {
            _ssh = ssh;
        }

        public SSH New => _ssh;

        /// <summary>
        /// 选择PuTTY会话配置文件
        /// </summary>
        public void ButtonSelectSessionConfigFile_OnClick()
        {
            var path = SelectFileHelper.OpenFile(
                title: "Select a PuTTY session file",
                filter: "PuTTY session file|*.ppk;*.reg"
            );
            if (!string.IsNullOrEmpty(path))
            {
                New.ExternalKittySessionConfigPath = path;
            }
        }
    }
}