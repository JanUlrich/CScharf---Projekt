using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auftragsmanagement_System.Models
{
    class City
    {
        private Int32 id;
        private string postalCode;
        private string name;
        private Country country;

        public City()
        {
            PostalCode = "";
            Name = "";
            Country = new Country();
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Country Country
        {
            get { return country; }
            set { country = value; }
        }
    }
}
