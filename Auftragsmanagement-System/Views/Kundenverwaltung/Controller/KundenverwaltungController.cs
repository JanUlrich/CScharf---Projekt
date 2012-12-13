using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Auftragsmanagement_System.Framework;
using Auftragsmanagement_System.Kundenverwaltung2.ViewModel;
using Auftragsmanagement_System.Models;
using Auftragsmanagement_System.Views.ActionBar.View;
using Auftragsmanagement_System.Views.ActionBar.ViewModel;
using Auftragsmanagement_System.Views.Kundenverwaltung2.View;
using Uebung_12.Framework;

namespace Auftragsmanagement_System.Kundenverwaltung2.Controller
{
    internal class KundenverwaltungController
    {

        private KundenverwaltungViewModel mViewModel;
        private ActionBarViewModel mActionBarViewModel;
        private Repository<Customer> mCustomerRepository;
        //private Repository<Address> mAddressRepository;

        public UserControl Initialize(ActionBarView actionBar, string databaseName)
        {
            UserControl view = new KundenverwaltungView();

            mCustomerRepository =
                new Repository<Customer>(
                    databaseName);
            mViewModel = new KundenverwaltungViewModel
            {
                Models = new ObservableCollection<Customer>(mCustomerRepository.GetAll()),
                SelectedModel = null
            };
            view.DataContext = mViewModel;

            mActionBarViewModel = new ActionBarViewModel
            {
                Command1 = new RelayCommand(AddCommandExecute),
                Command2 = new RelayCommand(DeleteCommandExecute, DeleteCommandCanExecute),
                Command3 = new RelayCommand(SaveCommandExecute, SaveCommandCanExecute),
                Command1Text = "Neu",
                Command2Text = "Löschen",
                Command3Text = "Speichern"
            };
            actionBar.DataContext = mActionBarViewModel;
            return view;
        }

        private void AddCommandExecute(object obj)
        {
            var cust = new Customer();

            mViewModel.SelectedModel = cust;
            mViewModel.Models.Add(mViewModel.SelectedModel);
            //mCustomerRepository.Save(mViewModel.SelectedModel);
        }

        private void DeleteCommandExecute(object obj)
        {
            mCustomerRepository.Delete(mViewModel.SelectedModel);
        }
        private bool DeleteCommandCanExecute(object obj)
        {
            return mViewModel.SelectedModel != null;
        }

        private void SaveCommandExecute(object obj)
        {
            var mModel = mViewModel.SelectedModel;
            var adressen = new List<Address>();
            mCustomerRepository.GetAll().ForEach((a) => adressen.Add(a.Address));
            mModel.Address = Address.KontrolliereMitDatenbank(mModel.Address, adressen);
            mCustomerRepository.Save(mModel);
        }
        private bool SaveCommandCanExecute(object obj)
        {
            return mViewModel.SelectedModel != null;
        }
    }
}