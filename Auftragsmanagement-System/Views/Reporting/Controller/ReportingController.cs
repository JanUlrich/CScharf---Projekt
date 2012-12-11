using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auftragsmanagement_System.Models;

namespace Auftragsmanagement_System.Views.Reporting.Controller
{
    class ReportingController
    {
        private ObservableCollection<Article> GibMeistverkaufteArtikel(ObservableCollection<OrderLine> orders)
        {
            var list = new List<ArticleCount>();
            foreach (var order in orders)
            {
                var articleCount=new ArticleCount(order.Article);
                if (list.Contains(articleCount))
                {
                    list[list.IndexOf(articleCount)].Count++;
                }else{
                    list.Add(new ArticleCount(order.Article));
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
         

    }
}
