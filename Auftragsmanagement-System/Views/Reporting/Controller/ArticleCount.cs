using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auftragsmanagement_System.Models;

namespace Auftragsmanagement_System.Views.Reporting.Controller
{
    class ArticleCount
    {
        public Article Article;
        public int Count = 0;
        
        public ArticleCount(Article article)
        {
            Article = article;
        }
        
        
    }
}
