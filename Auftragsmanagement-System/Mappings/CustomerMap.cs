using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auftragsmanagement_System.Models;
using FluentNHibernate.Mapping;

namespace Auftragsmanagement_System.Mappings
{
    class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Table("Customers");
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.Type).Not.Nullable();
            Map(x => x.Name).Length(100).Not.Nullable();
            Map(x => x.Firstname).Length(100);
            Map(x => x.Title).CustomType<Title>();
            Map(x => x.CustomerNumber).Length(50).Not.Nullable();
            Map(x => x.IsActive).Not.Nullable();
            //Id(x => x.Address.Id).Column("AddressId").Unique().Not.Nullable();
            References<Address>(x => x.Address, "AddressId").Not.Nullable().Unique().Cascade.All();

        }
    }
}
