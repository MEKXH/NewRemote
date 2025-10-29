using System.Windows.Controls;
using System.Windows.Input;

namespace _1RM.View.ServerView
{
    /// <summary>
    /// ServerTabsView.xaml 的交互逻辑
    /// </summary>
    public partial class ServerTabsView : UserControl
    {
        public ServerTabsView()
        {
            InitializeComponent();
        }

        private void TagList_PreviewMouseMoveEvent(object sender, MouseEventArgs e)
        {
            ServerPageView_TagListHelper.TagList_PreviewMouseMoveEvent(sender, e);
        }

        private void TagList_OnDrop(object sender, System.Windows.DragEventArgs e)
        {
            ServerPageView_TagListHelper.TagList_OnDrop(DataContext, sender, e);
        }

        private void HeaderTag_OnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            ServerPageView_TagListHelper.HeaderTag_OnClick(DataContext, sender, e);
        }
    }
}