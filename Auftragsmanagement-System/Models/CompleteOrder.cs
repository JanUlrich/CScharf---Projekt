using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auftragsmanagement_System.Models
{
    class CompleteOrder //TODO: Diese Klasse wird möglicherweise nicht gebraucht und kann gelöscht werden...
    {
        private Order order;
        private List<OrderLine> orderlines;

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
    }
}
