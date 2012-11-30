using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auftragsmanagement_System.Models;
using FluentNHibernate.Mapping;

namespace Auftragsmanagement_System.Mappings
{
    class CityMap : ClassMap<City>
    { 
        public CityMap()
        {
            Table("Cities");
            Id(x => x.Id).Not.Nullable();
            Map(x => x.PostalCode).Length(10).Not.Nullable();
            Map(x => x.Name).Length(100).Not.Nullable();
            References<Country>(x => x.Country, "CountryId");

        }
    }
}
