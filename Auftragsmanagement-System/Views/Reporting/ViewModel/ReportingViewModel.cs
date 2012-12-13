using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Auftragsmanagement_System.Framework;
using Auftragsmanagement_System.Models;
using Auftragsmanagement_System.Views.Reporting.Controller;

namespace Auftragsmanagement_System.Views.Reporting.ViewModel
{
    class ReportingViewModel : ViewModelBase
    {
        //Die Condition-Felder:
        private DateTime von;
        private DateTime bis;
        private string area;

        private ObservableCollection<Counter<Article>> topArtikel;
        private ObservableCollection<Counter<Employee>> topMitarbeiter;
        private ObservableCollection<Counter<Customer>> topKunden; 

        private ICommand zeigeMitarbeiterReporting;
        private ICommand zeigeKundenReporting;
        private ICommand zeigeArtikelReporting;
        private ICommand aktualisiereReporting;

        public ReportingViewModel()
        {
            Von = new DateTime();
            Bis = DateTime.Now;
            area = "";
        }


        public ObservableCollection<Counter<Article>> TopArtikel
        {
            get { return topArtikel; }
            set { topArtikel = value; 
            OnPropertyChanged("TopArtikel");}
        }

        public string Area
        {
            get { return area; }
            set { area = value; 
            OnPropertyChanged("Area");}
        }

        public DateTime Bis
        {
            get { return bis; }
            set { bis = value; 
            OnPropertyChanged("Bis");}
        }

        public DateTime Von
        {
            get { return von; }
            set { von = value; 
            OnPropertyChanged("Von");}
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

        public ObservableCollection<Counter<Employee>> TopMitarbeiter
        {
            get { return topMitarbeiter; }
            set { topMitarbeiter = value; 
            OnPropertyChanged("TopMitarbeiter");}
        }

        public ICommand AktualisiereReporting
        {
            get { return aktualisiereReporting; }
            set { aktualisiereReporting = value; }
        }

        public ObservableCollection<Counter<Customer>> TopKunden
        {
            get { return topKunden; }
            set { topKunden = value; }
        }
    }
}
