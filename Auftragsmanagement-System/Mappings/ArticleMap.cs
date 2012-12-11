using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auftragsmanagement_System.Models;
using FluentNHibernate.Mapping;

namespace Auftragsmanagement_System.Mappings
{
    class ArticleMap : ClassMap<Article>
    {
        public ArticleMap(){
            Table("Articles");
            Id(x => x.Id).Unique().Not.Nullable();
            Map(x => x.ArticleNumber).Length(50).Not.Nullable();
            Map(x => x.Name).Length(100).Not.Nullable();
            Map(x => x.Description).Length(100);
            Map(x => x.Price).Not.Nullable();
            Map(x => x.ValidFrom).Not.Nullable();
            Map(x => x.ValidTo).Not.Nullable();

        }
    }
}
