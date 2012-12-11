using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Auftragsmanagement_System.Models;
using FluentNHibernate.Mapping;

namespace Auftragsmanagement_System.Mappings
{
    class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Table("Orders");
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.OrderNumber).Length(50).Not.Nullable();
            Map(x => x.Description).Length(500);
            Map(x => x.OrderDate).CustomType<DateTime>().Not.Nullable();
            //Map(x => x.AddressId);
            References<Employee>(x => x.Employee, "EmployeeId");
            References<Address>(x => x.Customer, "CustomerId");

        }
    }
}
