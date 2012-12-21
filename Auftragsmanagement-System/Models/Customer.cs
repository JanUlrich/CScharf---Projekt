﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auftragsmanagement_System.Models
{
    class Customer
    {
        private Int32 id;
        private Int32 type;
        private string name;
        private string firstname;
        private Title title;
        private string customerNumber;
        private bool isActive;
        private Address address;

        public Customer()
        {
            //id = 0;
            CustomerNumber = "";
            Name = "";
            Firstname = "";
            Title = Title.keinTitel;
            IsActive = false;
            Address = new Address();
            Type = 0;
        }

        public Address Address
        {
            get { return address; }
            set { address = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public string CustomerNumber
        {
            get { return customerNumber; }
            set { customerNumber = value; }
        }

        public string Titel
        {
            get
            {
                return Auftragsmanagement_System.Framework.StringValueAttribute.GetStringValue(Title);
            }
        }

        public Title Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Customer)) return false;
            return ((Customer)obj).CustomerNumber == CustomerNumber;
        }

        public override int GetHashCode()
        {
            return CustomerNumber.GetHashCode();
        }

        public override string ToString()
        {
            return CustomerNumber + ", " + Firstname + " " + Name;
        }
    }
}
