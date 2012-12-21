using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Remotion.Linq.Collections;

namespace Auftragsmanagement_System.Models
{
    class CompleteOrder
    {
        private Order order;
        private List<OrderLine> orderlines;
        private ObservableCollection<OrderLine> orderCollection; 

        public CompleteOrder(Order ord, List<OrderLine> lines)
        {
            Order = ord;
            Orderlines = lines;
        }

        public static List<CompleteOrder> GeneriereOrders(List<Order> orders, List<OrderLine> lines)
        {
            var ret = new List<CompleteOrder>();
            foreach (var order1 in orders)
            {
                var order = new CompleteOrder(order1, new List<OrderLine>());
                ret.Add(order);
                foreach (var orderLine in lines)
                {
                    if (orderLine.Order.Id == order1.Id)
                    {
                        order.Orderlines.Add(orderLine);
                    }
                }

            }
            return ret;
        }

        public Order Order
        {
            get { return order; }
            set { order = value; }
        }

        public List<OrderLine> Orderlines
        {
            get { return orderlines; }
            set { orderlines = value; }
        }

        public ObservableCollection<OrderLine> OrderCollection
        {
            get
            {
                if (Orderlines == null) return null;
                var ret = new ObservableCollection<OrderLine>();
                foreach (var orderline in Orderlines)
                {
                    ret.Add(orderline);
                }
                return ret;
            }
            set { if(value!=null)Orderlines = value.ToList();
                if (value == null) Orderlines = null;
            }
        }
    }
}
