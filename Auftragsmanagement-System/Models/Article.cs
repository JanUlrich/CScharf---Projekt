using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Auftragsmanagement_System.Views.Reporting.Controller;

namespace Auftragsmanagement_System.Models
{
    public class Article
    {
        private Int32 id;
        private string articleNumber;
        private string name;
        private string description;
        private Decimal price;
        private DateTime validFrom;
        private DateTime validTo;

        public Article()
        {
            articleNumber = "1";
            name = "";
            description = "";
            price = 0;
            validFrom = DateTime.Now;
            validTo = DateTime.MaxValue;
        }

        [XmlElement("GueltigBis")]
        public DateTime ValidTo
        {
            get { return validTo; }
            set { validTo = value; }
        }

        [XmlElement("GueltigAb")]
        public DateTime ValidFrom
        {
            get { return validFrom; }
            set { validFrom = value; }
        }


        [XmlElement("Preis")]
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }


        [XmlElement("Beschreibung")]
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

        [XmlElement("Artikelnummer")]
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

        public override bool Equals(object obj)
        {
            if (!(obj is Article)) return false;
            return ((Article)obj).ArticleNumber == ArticleNumber;
        }

    }
}
