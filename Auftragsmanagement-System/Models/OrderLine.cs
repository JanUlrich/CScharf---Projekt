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
        private Order order;
        private Article article;

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

        public Article Article
        {
            get { return article; }
            set { article = value; }
        }

        public Order Order
        {
            get { return order; }
            set { order = value; }
        }
    }
}
