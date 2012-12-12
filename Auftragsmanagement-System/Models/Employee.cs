using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auftragsmanagement_System.Framework;

namespace Auftragsmanagement_System.Models
{
    public enum Title
    {   [StringValue("")]
        keinTitel = 0,
        [StringValue("Dipl.-Ing.")]
        Dipl_Ing = 1,
        [StringValue("Dr.")]
        Dr = 2,
        [StringValue("Dr. Dr.")]
        DrDr = 3,
        [StringValue("Prof.")]
        Prof = 4,
        [StringValue("Prof. Dr.")]
        Prof_Dr = 5,
        [StringValue("Prof. Dr. Dr.")]
        Prof_Dr_Dr = 6

    }

    public enum Type
    {
        [StringValue("Organisation")]
        Organisation = 0,
        [StringValue("Person")]
        Person = 1
    }

    class Employee
    {
        private Int32 id;
        private Int32 employeeNumber;
        private string _lastname;
        private string _firstname;
        private Title title;
        private string area;
        private bool isActive;
        //private Int32 addressID;
        private Address address;

        public Employee()
        {
            //id = 0;
            EmployeeNumber = 0;
            Lastname = "";
            Firstname = "";
            Title = Title.keinTitel;
            Area = "";
            IsActive = false;
            Address = new Address();
        }
        /*
        public void SaveIntoDatabase(string databaseFile)
        {
            var mEmployeeRepository = new Repository<Employee>(databaseFile);
            var mEmployeeRepository = new Repository<Address>(databaseFile);
            var mCityRepository = new Repository<City>(databaseFile);
            var mCountryRepository = new Repository<Country>(databaseFile);
            mEmployeeRepository.Save(Address.City.Country);
        }
        */
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int EmployeeNumber
        {
            get { return employeeNumber; }
            set { employeeNumber = value; }
        }

        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        public Title Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Area
        {
            get { return area; }
            set { area = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public Address Address
        {
            get { return address; }
            set { address = value; }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Employee)) return false;
            return ((Employee)obj).EmployeeNumber == EmployeeNumber;
        }

        public override int GetHashCode()
        {
            return EmployeeNumber;
        }

    }
}
