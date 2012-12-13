using System.Windows.Controls;
using System.Windows.Input;
using Auftragsmanagement_System.Framework;

namespace Auftragsmanagement_System.Views.MainWindow.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        private UserControl content;
        private UserControl actionBar;
        private ICommand zeigeMitarbeiterverwaltung;
        private ICommand zeigeReporting;
        private ICommand zeigeArtikelverwaltung;
        private ICommand zeigeAuftragsverwaltung;

        public UserControl Content
        {
            get { return content; }
            set { content = value;
            OnPropertyChanged("Content");}
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

        public ICommand ZeigeArtikelverwaltung
        {
            get { return zeigeArtikelverwaltung; }
            set { zeigeArtikelverwaltung = value; }
        }

        public ICommand ZeigeAuftragsverwaltung
        {
            get { return zeigeAuftragsverwaltung; }
            set { zeigeAuftragsverwaltung = value; }
        }
    }
}
