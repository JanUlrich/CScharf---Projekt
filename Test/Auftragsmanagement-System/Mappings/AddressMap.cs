using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auftragsmanagement_System.Models;
using FluentNHibernate.Mapping;

namespace Auftragsmanagement_System.Mappings
{
    class AddressMap : ClassMap<Address>
    { 
        public AddressMap()
        {
            Table("Adresses");
            Id(x => x.Id).Not.Nullable();
            Map(x => x.Street).Length(100);
            Map(x => x.StreetNumber).Length(5);
            References<City>(x => x.City, "CityId");

        }
    }
}
