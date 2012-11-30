using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auftragsmanagement_System.Models;
using FluentNHibernate.Mapping;

namespace Auftragsmanagement_System.Mappings
{
    class CountryMap : ClassMap<Country>
    { 
        public CountryMap()
        {
            Table("Countries");
            Id(x => x.Id).Not.Nullable();
            Map(x => x.Name).Length(100).Not.Nullable();
        }
    }
}
