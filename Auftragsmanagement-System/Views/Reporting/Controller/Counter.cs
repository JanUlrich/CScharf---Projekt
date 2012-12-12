using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auftragsmanagement_System.Models;

namespace Auftragsmanagement_System.Views.Reporting.Controller
{
    class Counter<T> where T : class
    {
        private T toCount;
        private int count;

        public Counter(T obj)
        {
            ToCount = obj;
        } 

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public T ToCount
        {
            get { return toCount; }
            set { toCount = value; }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Counter<T>)) return false;
            return ((Counter<T>)obj).ToCount.Equals(ToCount);
        }

        public override int GetHashCode()
        {
            return ToCount.GetHashCode();
        }

        public static ObservableCollection<T> SortiereNachMaxCount(List<Counter<T>> list, int anzahl)
        {
            var ret = new List<Counter<T>>(list);
            ret.Sort((a1, a2) => a2.Count.CompareTo(a1.Count));//Die Liste sortieren. Den Artikel mit dem höchsten "Count" an oberster Stelle
            if (ret.Count > 10) ret.RemoveRange(10, ret.Count - 10);//Alle überschüssigen Elemente entfernen (wir wollen nur die ersten 10)
            
            var ret2 = new ObservableCollection<T>(); //Observable Collection bilden
            foreach (var articleCount in ret)
            {
                ret2.Add(articleCount.ToCount);
            }
            
            return ret2;
        }

    }
}
