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

        public UserControl Initialize(ActionBarView actionBar)
        {
            UserControl view = new MitarbeiterverwaltungView();
            mEmployeeRepository =
                new Repository<Employee>(
                    @"F:\AndiStuff\Visual Studio Workspace\Auftragsmanagement-System\Auftragsmanagement-System\Database\CompanyManagementSystem.db");
                //TODO: hier den absoluten Verweis ersetzen

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
            memployees.Sort((e1, e2) => e1.EmployeeNumber.CompareTo(e2.EmployeeNumber));
            emp.EmployeeNumber = memployees[0].EmployeeNumber + 1;
            MessageBox.Show("neue Employee Nummer = "+ emp.EmployeeNumber); //TODO diese Debugausgabe entfernen (zuvor testen, ob richtige Nummer vergeben wird)
            /*
            foreach (var memp in mEmployeeRepository.GetAll())
            {
                memp.EmployeeNumber
            }
             */

            mViewModel.SelectedModel = emp;
            //mViewModel.Models.Add(mViewModel.SelectedModel); //erst beim Speichern adden
            //oder andere Möglichkeit: Die Employees werden in die Liste eingefügt und können editiert werden. Erst bei einem Druck auf Speichern werden sie gespeichert. Neu in die Liste aufgenommene werden mit Stern gekennzeichnet.
        }

        private void DeleteCommandExecute(object obj)
        {
            //TODO : Delete COmmand implementieren
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