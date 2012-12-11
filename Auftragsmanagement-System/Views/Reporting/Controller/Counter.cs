using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (!(obj is T)) return false;
            return ((T)obj).Equals(ToCount);
        }

    }
}
