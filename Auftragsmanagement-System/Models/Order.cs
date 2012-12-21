using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auftragsmanagement_System.Models
{
    class Order
    {
        private Int32 id;
        private string orderNumber;
        private DateTime orderDate;
        private string description;
        //private Int32 employeeId;
        //private Int32 customerId;
        private Employee employee;
        private Customer customer;
        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }

        public DateTime OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }

        public DateTime Bestelldatum
        {
            get { return OrderDate.Date; }
            set { OrderDate = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public Employee Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }
    }
}
