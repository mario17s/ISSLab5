using System.Windows.Controls;
using CodeBuddies.ViewModels;

namespace CodeBuddies.Views.UserControls
{
    /// <summary>
    /// Interaction logic for SessionsPanel.xaml
    /// </summary>
    public partial class SessionsPanel : UserControl
    {
        public SessionsPanel()
        {
            InitializeComponent();
            DataContext = new SessionsListViewModel();
        }
    }
}
