using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auftragsmanagement_System.Framework;
using Auftragsmanagement_System.Models;

namespace Auftragsmanagement_System.Database
{
    class Datenbank
    {
        private Repository<Employee> mEmployeeRepository;
        private Repository<Address> mAddressRepository;
        private Repository<City> mCityRepository; 

        public Datenbank()
        {
            string databaseName =
                @"F:\AndiStuff\Visual Studio Workspace\Auftragsmanagement-System\Auftragsmanagement-System\Database\CompanyManagementSystem.db";
            mEmployeeRepository =
                new Repository<Employee>(
                    databaseName);
        }

        public List<Employee> GetEmployees()
        {
            var ret = mEmployeeRepository.GetAll();
            return ret;
        } 
        
        public void SaveOrUpdateEmployee(Employee employee)
        {
            var addresses = mAddressRepository.GetAll();
            foreach (var address in addresses)
            {
                if (employee.Address.City.Name == address.City.Name) ;
            }
            mEmployeeRepository.Save(employee);
        }

        private City GetCorrespondingItemFromDatabase(City city)

        {
            return null;
        }

    }
}
