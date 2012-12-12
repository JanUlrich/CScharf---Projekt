using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Auftragsmanagement_System.Framework;
using Auftragsmanagement_System.MainWindow.View;
using Auftragsmanagement_System.Mitarbeiterverwaltung.Controller;
using Auftragsmanagement_System.Mitarbeiterverwaltung.View;
using Auftragsmanagement_System.Models;
using Auftragsmanagement_System.Views.ActionBar.Controller;
using Auftragsmanagement_System.Views.ActionBar.View;
using Auftragsmanagement_System.Views.MainWindow.ViewModel;
using Auftragsmanagement_System.Views.Reporting.Controller;
using Uebung_12.Framework;

namespace Auftragsmanagement_System.Views.MainWindow.Controller
{
    class MainWindowController
    {
        private ActionBarView ActionBar;
        private UserControl mMitarbeiterverwaltung;
        private UserControl mReporting;
        private MainWindowViewModel mViewModel;
        private string mDatabaseName;
        private MainWindowView mView;

        public void Initialize(string databaseName)
        {
            mDatabaseName = databaseName;
            ActionBar = new ActionBarController().Initialize();
            mView = new MainWindowView();
            mMitarbeiterverwaltung = new ReportingController().Initialize(mDatabaseName);//new MitarbeiterverwaltungController().Initialize(ActionBar, databaseName);//
            mViewModel = new MainWindowViewModel
            {
                Content = mMitarbeiterverwaltung,
                ActionBar = ActionBar,
                ZeigeMitarbeiterverwaltung = new RelayCommand(ZeigeMitarbeiterverwaltungExecute),
                ZeigeReporting = new RelayCommand(ZeigeReportingExecute)
            };
            mView.DataContext = mViewModel;
            mView.ShowDialog();
        }

        private void ZeigeMitarbeiterverwaltungExecute(object obj)
        {
            mViewModel.Content = mMitarbeiterverwaltung;
        }

        private void ZeigeReportingExecute(object obj)
        {
            mReporting = new ReportingController().Initialize(mDatabaseName);
            mViewModel.Content = mReporting;
            //mView.DataContext = mViewModel;
            //((MainWindowViewModel)mView.DataContext).Content = mReporting;
        }
    }
}
