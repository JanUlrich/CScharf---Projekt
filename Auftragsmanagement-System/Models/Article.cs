using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auftragsmanagement_System.Models
{
    class Article
    {
        private Int32 id;
        private string articleNumber;
        private string name;
        private string description;
        private Decimal price;
        private DateTime validFrom;
        private DateTime validTo;

        public DateTime ValidTo
        {
            get { return validTo; }
            set { validTo = value; }
        }

        public DateTime ValidFrom
        {
            get { return validFrom; }
            set { validFrom = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ArticleNumber
        {
            get { return articleNumber; }
            set { articleNumber = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
