using System.Windows.Controls;

namespace Auftragsmanagement_System.Views.MainWindow.ViewModel
{
    class MainWindowViewModel
    {
        private UserControl content;
        private UserControl actionBar;

        public UserControl Content
        {
            get { return content; }
            set { content = value; }
        }

        public UserControl ActionBar
        {
            get { return actionBar; }
            set { actionBar = value; }
        }
    }
}
