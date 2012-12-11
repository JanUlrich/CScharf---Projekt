using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auftragsmanagement_System.Models;
using FluentNHibernate.Mapping;

namespace Auftragsmanagement_System.Mappings
{
    class OrderLineMap : ClassMap<OrderLine>
    {
        public OrderLineMap()
        {
            Table("OrderLines");
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.Amount).Not.Nullable();
            Map(x => x.Position).Length(500);
            //Map(x => x.AddressId);
            HasMany<Order>(x => x.Order).Inverse().Cascade.SaveUpdate().KeyColumn("");
            References<Article>(x => x.Article, "ArticleId").Cascade.SaveUpdate();

        }
    }
}
