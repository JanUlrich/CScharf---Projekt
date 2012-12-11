using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Auftragsmanagement_System.Framework;
using Auftragsmanagement_System.Models;
using Auftragsmanagement_System.Views.Reporting.View;
using Auftragsmanagement_System.Views.Reporting.ViewModel;
using Uebung_12.Framework;

namespace Auftragsmanagement_System.Views.Reporting.Controller
{
    class ReportingController
    {
        private string mDatabaseName;
        private ReportingViewModel mViewModel;

        public UserControl Initialize(string databasename)
        {
            var ret = new ReportingView();
            mDatabaseName = databasename;
            
            mViewModel = new ReportingViewModel
                                  {
                                      ZeigeMitarbeiterReporting = new RelayCommand(ZeigeMitarbeiterReportingExecute),
                                      ZeigeArtikelReporting = new RelayCommand(ZeigeArtikelReportingExecute)
                                  };
            
            ret.DataContext = mViewModel;
            return ret;
        }

        private void ZeigeArtikelReportingExecute(object obj)
        {
            ObservableCollection<OrderLine> orders = new ObservableCollection<OrderLine>(new Repository<OrderLine>(mDatabaseName).GetAll());
            mViewModel.TopArtikel = GibMeistverkaufteArtikel(orders, new DateTime(0), DateTime.Now, null);
        }

        private void ZeigeMitarbeiterReportingExecute(object obj)
        {
            
        }
        
        private ObservableCollection<Article> GibMeistverkaufteArtikel(ObservableCollection<OrderLine> orders, DateTime von, DateTime bis, string area)
        {
            var list = new List<Counter<Article>>();
            foreach (var order in orders)
            {
                if(MatchesConditions(order.Order.OrderDate, order.Order.Employee.Area)){//wenn die Order in der Vorgegebenen Zeitspanne und Area war
                    var articleCount = new Counter<Article>(order.Article);
                    if (list.Contains(articleCount))
                    {
                        list[list.IndexOf(articleCount)].Count++;
                    }else{
                        list.Add(new Counter<Article>(order.Article));
                    }
                }
            }
            list.Sort((a1,a2)=>a2.Count.CompareTo(a1.Count)); //Die Liste sortieren. Den Artikel mit dem höchsten "Count" an oberster Stelle
            if(list.Count>10)list.RemoveRange(10,list.Count-10);//Alle überschüssigen Elemente entfernen (wir wollen nur die ersten 10)

            var ret = new ObservableCollection<Article>(); //Observable Collection bilden
            foreach (var articleCount in list)
            {
                ret.Add(articleCount.ToCount);
            }
            return ret;
        }

        private ObservableCollection<Employee> GibBesteMitarbeiter(ObservableCollection<Employee> emps, List<CompleteOrder> orders)
        {
            var list = new List<Employee>();
            foreach (var order in orders)
            {
                foreach (var emp in emps)
                {
                    //if(order.Order.Employee.EmployeeNumber == order.Order.)
                }   
            }
            return null;
        }


        /// <summary>
        /// Anmerkung: Falls der in der ReportingView spezifizierte Area-String leer ist, dann gelten alle Bereiche
        /// </summary>
        /// <returns></returns>
        private bool MatchesConditions(DateTime time, string area)
        {
            if (time == null) return false;
            return (time.CompareTo(mViewModel.Von) >= 0 && time.CompareTo(mViewModel.Bis) <= 0 &&
                (area == null || area == "" || mViewModel.Area == area)) ;
        }

    }
}
