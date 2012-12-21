using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Auftragsmanagement_System.Views.Reporting.Controller;

namespace Auftragsmanagement_System.Models
{
    [XmlType("Artikel")]
    public class Article
    {
        private Int32 id;
        private string articleNumber;
        private string name;
        private string description;
        private Decimal price;
        private DateTime validFrom;
        private DateTime validTo;
        //sind für die XML-Serialisierung:
        private string gueltigBis;
        private string gueltigAb;
        private string preis;

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

        //[XmlIgnore]
        [XmlElement("GueltigAb")]
        public DateTime ValidFrom
        {
            get { return validFrom; }
            set { validFrom = value; }
        }


        [XmlIgnore]
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
        /*
        public string GueltigBis
        {
            get { return ""; }
            set
            {
                DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                dtfi.ShortDatePattern = "dd-MM-yyyy";
                dtfi.DateSeparator = "-";
                DateTime objDate = Convert.ToDateTime(value, dtfi);
                ValidTo = objDate;
            }
        }

        public string GueltigAb
        {
            get { return ""; }
            set
            {
                DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                dtfi.ShortDatePattern = "dd-MM-yyyy";
                dtfi.DateSeparator = "-";
                DateTime objDate = Convert.ToDateTime(value, dtfi);
                ValidFrom = objDate;
            }
        }
        */
        public string Preis
        {
            get { return Price.ToString(); }
            set
            {
                Decimal val;
                if (!decimal.TryParse(value.Replace(",", "").Replace(".", ""), NumberStyles.Number, CultureInfo.InvariantCulture, out val))Price = 0;
                Price = val / 100;
                preis = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Article)) return false;
            return ((Article)obj).ArticleNumber == ArticleNumber;
        }

        public override string ToString()
        {
            return ArticleNumber;
        }

    }
}
