using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Auftragsmanagement_System.Models;
using FluentNHibernate.Mapping;

namespace Auftragsmanagement_System.Mappings
{
    class EmployeeMap : ClassMap<Employee>
    { 
        public EmployeeMap()
        {
            Table("Employees");
            Id(x => x.Id).Not.Nullable();
            Map(x => x.Firstname).Length(100).Not.Nullable();
            Map(x => x.Lastname).Length(100).Not.Nullable();
            Map(x => x.Title).CustomType<Title>().Not.Nullable();
            Map(x => x.Area).Length(10);
            Map(x => x.IsActive).Not.Nullable();
            Map(x => x.AddressId);
            References<Address>(x => x.Address, "AddressId");

        }
    }
}
