using System.Windows.Controls;
using System.Windows.Input;

namespace Auftragsmanagement_System.Views.MainWindow.ViewModel
{
    class MainWindowViewModel
    {
        private UserControl content;
        private UserControl actionBar;
        private ICommand zeigeMitarbeiterverwaltung;
        private ICommand zeigeReporting;

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

        public ICommand ZeigeMitarbeiterverwaltung
        {
            get { return zeigeMitarbeiterverwaltung; }
            set { zeigeMitarbeiterverwaltung = value; }
        }

        public ICommand ZeigeReporting
        {
            get { return zeigeReporting; }
            set { zeigeReporting = value; }
        }
    }
}
