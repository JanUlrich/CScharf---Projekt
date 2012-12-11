using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Auftragsmanagement_System.Framework;
using Auftragsmanagement_System.Mitarbeiterverwaltung.View;
using Auftragsmanagement_System.Mitarbeiterverwaltung.ViewModel;
using Auftragsmanagement_System.Models;
using Auftragsmanagement_System.Views.ActionBar.View;
using Auftragsmanagement_System.Views.ActionBar.ViewModel;
using Uebung_12.Framework;

namespace Auftragsmanagement_System.Mitarbeiterverwaltung.Controller
{
    internal class MitarbeiterverwaltungController
    {

        private MitarbeiterverwaltungViewModel mViewModel;
        private ActionBarViewModel mActionBarViewModel;
        private Repository<Employee> mEmployeeRepository;
        //private Repository<Address> mAddressRepository;

        public UserControl Initialize(ActionBarView actionBar, string databaseName)
        {
            UserControl view = new MitarbeiterverwaltungView();
            
            mEmployeeRepository =
                new Repository<Employee>(
                    databaseName);
                //TODO: hier den absoluten Verweis ersetzen
            //mAddressRepository = new Repository<Address>(databaseName);
            mViewModel = new MitarbeiterverwaltungViewModel
                             {
                                 Models = new ObservableCollection<Employee>(mEmployeeRepository.GetAll()),
                                 SelectedModel = null
                             };
            view.DataContext = mViewModel;

            mActionBarViewModel = new ActionBarViewModel
                                      {
                                          AddCommand = new RelayCommand(AddCommandExecute),
                                          DeleteCommand = new RelayCommand(DeleteCommandExecute, DeleteCommandCanExecute),
                                          SaveCommand = new RelayCommand(SaveCommandExecute, SaveCommandCanExecute)
                                      };
            actionBar.DataContext = mActionBarViewModel;
            return view;
        }

        private void AddCommandExecute(object obj)
        {
            var emp = new Employee();
            
            //hier wird die EmployeeNumber gesetzt:
            var memployees = mEmployeeRepository.GetAll();
            memployees.Sort((e1, e2) => e2.EmployeeNumber.CompareTo(e1.EmployeeNumber));
            if(memployees.Count>0){emp.EmployeeNumber = memployees[0].EmployeeNumber + 1;}else
            {
                emp.EmployeeNumber = 1;
            }
            //emp.Address = mAddressRepository.GetAll()[0];
            //MessageBox.Show("neue Employee Nummer = "+ emp.EmployeeNumber); //TODO diese Debugausgabe entfernen (zuvor testen, ob richtige Nummer vergeben wird)

            mViewModel.SelectedModel = emp;
            mViewModel.Models.Add(mViewModel.SelectedModel);
            mEmployeeRepository.Save(mViewModel.SelectedModel);

            //oder andere Möglichkeit: Die Employees werden in die Liste eingefügt und können editiert werden. Erst bei einem Druck auf Speichern werden sie gespeichert. Neu in die Liste aufgenommene werden mit Stern gekennzeichnet.
        }

        private void DeleteCommandExecute(object obj)
        {
            mEmployeeRepository.Delete(mViewModel.SelectedModel);
        }
        private bool DeleteCommandCanExecute(object obj)
        {
            return mViewModel.SelectedModel != null;
        }

        private void SaveCommandExecute(object obj)
        {
            mEmployeeRepository.Save(mViewModel.SelectedModel);
        }
        private bool SaveCommandCanExecute(object obj)
        {
            return mViewModel.SelectedModel != null;
        }
    }
}