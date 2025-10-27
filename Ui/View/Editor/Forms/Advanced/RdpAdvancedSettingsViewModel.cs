using _1RM.Model.Protocol;
using _1RM.View.Editor.Forms;
using Shawn.Utils;

namespace _1RM.View.Editor.Forms.Advanced
{
    public class RdpAdvancedSettingsViewModel : NotifyPropertyChangedBase
    {
        private readonly RDP _rdp;

        public RdpAdvancedSettingsViewModel(RDP rdp)
        {
            _rdp = rdp;
        }

        public RDP New => _rdp;
    }
}