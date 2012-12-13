using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
                                      ZeigeArtikelReporting = new RelayCommand(ZeigeArtikelReportingExecute),
                                      AktualisiereReporting = new RelayCommand(AktualisiereReportingExecute)
                                  };

            ret.DataContext = mViewModel;
            return ret;
        }

        private void AktualisiereReportingExecute(object obj)
        {
            //Alle Reportings aktualisieren und anzeigen:
            ZeigeArtikelReportingExecute(null);
            ZeigeMitarbeiterReportingExecute(null);
            ZeigeKundenReportingExecute(null);
        }

        private void ZeigeArtikelReportingExecute(object obj)
        {
            ObservableCollection<OrderLine> orders = new ObservableCollection<OrderLine>(new Repository<OrderLine>(mDatabaseName).GetAll());
            mViewModel.TopArtikel = GibMeistverkaufteArtikel(orders);
        }

        private void ZeigeMitarbeiterReportingExecute(object obj)
        {
            var orders = CompleteOrder.GeneriereOrders(new Repository<Order>(mDatabaseName).GetAll(),
                                          new Repository<OrderLine>(mDatabaseName).GetAll());
            mViewModel.TopMitarbeiter = GibBesteMitarbeiter(new Repository<Employee>(mDatabaseName).GetAll(), orders);
        }

        private void ZeigeKundenReportingExecute(object obj)
        {
            var orders = CompleteOrder.GeneriereOrders(new Repository<Order>(mDatabaseName).GetAll(),
                                          new Repository<OrderLine>(mDatabaseName).GetAll());
            mViewModel.TopKunden = GibBesteKunden(new Repository<Customer>(mDatabaseName).GetAll(), orders);
        }

        private ObservableCollection<Counter<Article>> GibMeistverkaufteArtikel(ObservableCollection<OrderLine> orders)
        {
            var list = new List<Counter<Article>>();
            foreach (var orderLine in orders)
            {
                list.Add(new Counter<Article>(orderLine.Article));
            }
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

            return Counter<Article>.SortiereNachMaxCount(list, 10);
            //list.Sort((a1,a2)=>a2.Count.CompareTo(a1.Count)); 
            //if(list.Count>10)list.RemoveRange(10,list.Count-10);

        }

        private ObservableCollection<Counter<Employee>> GibBesteMitarbeiter(List<Employee> emps, List<CompleteOrder> orders)
        {
            var list = new List<Counter<Employee>>();
            foreach (var employee in emps)
            {
                list.Add(new Counter<Employee>(employee));
            }
            foreach (var order in orders)
            {
                foreach (var emp in emps)
                {
                    if (order.Order.Employee.Equals(emp))
                    {
                        if (MatchesConditions(order.Order.OrderDate, order.Order.Employee.Area))
                        {//Erzielter Umsatz der Bestellung errechnen, wenn die Conditions stimmen:
                            foreach (var orderLine in order.Orderlines)
                            {
                                var umsatzCount = new Counter<Employee>(emp);
                                int umsatz = orderLine.Amount * Convert.ToInt32(orderLine.Article.Price);
                                if (list.Contains(umsatzCount))
                                {
                                    list[list.IndexOf(umsatzCount)].Count += umsatz;
                                }
                                else
                                {
                                    umsatzCount.Count += umsatz;
                                    list.Add(umsatzCount);
                                }
                            }
                        }
                    }
                    //if(order.Order.Employee.EmployeeNumber == order.Order.)
                }

            }
            return Counter<Employee>.SortiereNachMaxCount(list, 10);
        }

        private ObservableCollection<Counter<Customer>> GibBesteKunden(List<Customer> customers, List<CompleteOrder> orders)
        {
            var list = new List<Counter<Customer>>();
            foreach (var customer in customers)
            {
                list.Add(new Counter<Customer>(customer));
            }
            foreach (var order in orders)
            {
                foreach (var customer in customers)
                {
                    if (order.Order.Customer.Equals(customer))
                    {
                        if (MatchesConditions(order.Order.OrderDate, order.Order.Employee.Area))
                        {//Erzielter Umsatz der Bestellung errechnen, wenn die Conditions stimmen:
                            foreach (var orderLine in order.Orderlines)
                            {
                                var umsatzCount = new Counter<Customer>(customer);
                                int umsatz = orderLine.Amount * Convert.ToInt32(orderLine.Article.Price);
                                if (list.Contains(umsatzCount))
                                {
                                    list[list.IndexOf(umsatzCount)].Count += umsatz;
                                }
                                else
                                {
                                    umsatzCount.Count += umsatz;
                                    list.Add(umsatzCount);
                                }
                            }
                        }
                    }
                    //if(order.Order.Employee.EmployeeNumber == order.Order.)
                }

            }
            return Counter<Customer>.SortiereNachMaxCount(list, 10);
        }


        /// <summary>
        /// Anmerkung: Falls der in der ReportingView spezifizierte Area-String leer ist, dann gelten alle Bereiche
        /// </summary>
        /// <returns></returns>
        private bool MatchesConditions(DateTime time, string area)
        {
            if (time == null) return false;
            return (time.CompareTo(mViewModel.Von) >= 0 && time.CompareTo(mViewModel.Bis) <= 0 &&
                (string.IsNullOrEmpty(area) || string.IsNullOrEmpty(mViewModel.Area) || mViewModel.Area == area));
        }

    }
}
