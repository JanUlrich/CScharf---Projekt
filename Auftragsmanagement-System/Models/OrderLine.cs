using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auftragsmanagement_System.Models
{
    class OrderLine
    {
        private Int32 id;
        private Int32 amount;
        private Int32 position;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public int Position
        {
            get { return position; }
            set { position = value; }
        }
    }
}
