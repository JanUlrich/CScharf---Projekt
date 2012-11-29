using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auftragsmanagement_System.Models
{
    class Employee
    {
        private Int32 id;
        private Int32 employeeNumber;
        private string _lastname;
        private string _firstname;
        private Title title;
        private string area;
        private bool isActive;
        private Int32 addressID;
        private Address address;

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

        public int AddressId
        {
            get { return addressID; }
            set { addressID = value; }
        }
    }
}
