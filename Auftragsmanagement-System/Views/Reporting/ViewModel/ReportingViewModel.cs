using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Auftragsmanagement_System.Models;

namespace Auftragsmanagement_System.Views.Reporting.ViewModel
{
    class ReportingViewModel
    {
        //Die Condition-Felder:
        private DateTime von;
        private DateTime bis;
        private string area;

        private ObservableCollection<Article> topArtikel;
        private ObservableCollection<Employee> topMitarbeiter; 

        private ICommand zeigeMitarbeiterReporting;
        private ICommand zeigeKundenReporting;
        private ICommand zeigeArtikelReporting;

        public ReportingViewModel()
        {
            Von = new DateTime();
            Bis = DateTime.Now;
            area = "";
        }


        public ObservableCollection<Article> TopArtikel
        {
            get { return topArtikel; }
            set { topArtikel = value; }
        }

        public string Area
        {
            get { return area; }
            set { area = value; }
        }

        public DateTime Bis
        {
            get { return bis; }
            set { bis = value; }
        }

        public DateTime Von
        {
            get { return von; }
            set { von = value; }
        }

        public ICommand ZeigeArtikelReporting
        {
            get { return zeigeArtikelReporting; }
            set { zeigeArtikelReporting = value; }
        }

        public ICommand ZeigeKundenReporting
        {
            get { return zeigeKundenReporting; }
            set { zeigeKundenReporting = value; }
        }

        public ICommand ZeigeMitarbeiterReporting
        {
            get { return zeigeMitarbeiterReporting; }
            set { zeigeMitarbeiterReporting = value; }
        }

        public ObservableCollection<Employee> TopMitarbeiter
        {
            get { return topMitarbeiter; }
            set { topMitarbeiter = value; }
        }
    }
}
