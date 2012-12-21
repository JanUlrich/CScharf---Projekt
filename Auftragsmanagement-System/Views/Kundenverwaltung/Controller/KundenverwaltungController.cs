using System;
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
        private string mDatabaseName;
        //private Repository<Address> mAddressRepository;

        public UserControl Initialize(ActionBarView actionBar, string databaseName)
        {
            mDatabaseName = databaseName;
            UserControl view = new KundenverwaltungView();

            mCustomerRepository =
                new Repository<Customer>(
                    mDatabaseName);
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
            mViewModel.Models.Remove(mViewModel.SelectedModel);
        }
        private bool DeleteCommandCanExecute(object obj)
        {
            return (mViewModel.SelectedModel!=null)
            ;
        }

        private void SaveCommandExecute(object obj)
        {
            var mModel = mViewModel.SelectedModel;
            var adressen = new List<Address>();
            //string fehler = "";
            var addressRepository = new Repository<Address>(mDatabaseName);
            adressen = addressRepository.GetAll();
            try
            {
                mModel.Address = Address.KontrolliereMitDatenbank(mModel.Address, adressen);
                try
                {
                    mCustomerRepository.Save(mModel);
                }
                catch (Exception)
                {
                    MessageBox.Show("Kundennummer ist bereits vorhanden");
                }
            }
            catch (WrongCityPostalCodeCombination excp)
            {
                //fehler = "Fehler: Die Kombination aus Postleitzahl und Städtenamen ist nicht korrekt";
                MessageBox.Show("Fehler: Die Kombination aus Postleitzahl und Städtenamen ist nicht korrekt!\n" + excp.Message);
            }
        }
        private bool SaveCommandCanExecute(object obj)
        {
            return mViewModel.SelectedModel != null;
        }
    }
}