using System.Windows.Controls;

namespace _1RM.View.Editor.Forms.Advanced
{
    public partial class SshAdvancedSettingsView : UserControl
    {
        public SshAdvancedSettingsView()
        {
            InitializeComponent();
        }

        private void ButtonSelectSessionConfigFile_OnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is SshAdvancedSettingsViewModel vm)
            {
                vm.ButtonSelectSessionConfigFile_OnClick();
            }
        }
    }
}