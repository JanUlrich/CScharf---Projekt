using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auftragsmanagement_System.Models
{
    class Address
    {
        private Int32 id;
        private string street;
        private string streetNumber;
        //private Int32 cityId;
        private City city;

        public Address()
        {
            street = "";
            streetNumber = "";
            city = new City();
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Street
        {
            get { return street; }
            set { street = value; }
        }

        public string StreetNumber
        {
            get { return streetNumber; }
            set { streetNumber = value; }
        }

        public City City
        {
            get { return city; }
            set { city = value; }
        }
    }
}
