using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auftragsmanagement_System.Models
{
    class Country
    {
        private Int32 id;
        private string name;
        
        public static Country KontrolliereMitDatenbank(Country land, List<Country> länder)
        {
            foreach (var country in länder)
            {
                if (country.Name.Equals(land.Name)) return country;
            }
            return land;
        }

        public Country()
        {
            name = "";
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
