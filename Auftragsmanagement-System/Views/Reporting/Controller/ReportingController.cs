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

namespace Auftragsmanagement_System.Views.Reporting.Controller
{
    class ReportingController
    {
        private string mDatabaseName;

        public UserControl Initialize(string databasename)
        {
            var ret = new ReportingView();
            mDatabaseName = databasename;
            ObservableCollection<OrderLine> orders = new ObservableCollection<OrderLine>(new Repository<OrderLine>(mDatabaseName).GetAll());
            ret.DataContext = new ReportingViewModel
                                  {
                                      TopArtikel = GibMeistverkaufteArtikel(orders, new DateTime(0), DateTime.Now, null)
                                  };

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="area">hier null übergeben, falls alle Gebiete angezeigt werden sollen</param>
        /// <returns></returns>
        private ObservableCollection<Article> GibMeistverkaufteArtikel(ObservableCollection<OrderLine> orders, DateTime von, DateTime bis, string area)
        {
            var list = new List<ArticleCount>();
            foreach (var order in orders)
            {
                if(order.Order.OrderDate.CompareTo(von) >=0 && order.Order.OrderDate.CompareTo(bis) <=0 && (area == null || order.Order.Employee.Area == area)){//wenn die Order in der Vorgegebenen Zeitspanne und Area war
                    var articleCount=new ArticleCount(order.Article);
                    if (list.Contains(articleCount))
                    {
                        list[list.IndexOf(articleCount)].Count++;
                    }else{
                        list.Add(new ArticleCount(order.Article));
                    }
                }
            }
            list.Sort((a1,a2)=>a2.Count.CompareTo(a1.Count)); //Die Liste sortieren. Den Artikel mit dem höchsten "Count" an oberster Stelle
            if(list.Count>10)list.RemoveRange(10,list.Count-10);//Alle überschüssigen Elemente entfernen (wir wollen nur die ersten 10)

            var ret = new ObservableCollection<Article>(); //Observable Collection bilden
            foreach (var articleCount in list)
            {
                ret.Add(articleCount.Article);
            }
            return ret;
        }

        private ObservableCollection<Employee> GibBesteMitarbeiter(ObservableCollection<Employee> emps, List<OrderLine> orders)
        {
            var list = new List<Employee>();
            
            foreach (var emp in emps)
            {
                
            }
            return null;
        } 



    }
}
