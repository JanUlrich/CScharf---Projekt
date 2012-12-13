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
using Auftragsmanagement_System.Views.Artikelverwaltung.Controller;
using Auftragsmanagement_System.Views.Artikelverwaltung.View;
using Auftragsmanagement_System.Views.Auftragsverwaltung.Controller;
using Auftragsmanagement_System.Views.Auftragsverwaltung.View;
using Auftragsmanagement_System.Views.MainWindow.ViewModel;
using Auftragsmanagement_System.Views.Reporting.Controller;
using Uebung_12.Framework;

namespace Auftragsmanagement_System.Views.MainWindow.Controller
{
    class MainWindowController
    {
        private ActionBarView mActionBar;
        private UserControl mMitarbeiterverwaltung;
        private UserControl mReporting;
        private UserControl mArtikelverwaltung;
        private MainWindowViewModel mViewModel;
        private string mDatabaseName;
        private MainWindowView mView;

        public void Initialize(string databaseName)
        {
            mDatabaseName = databaseName;
            mActionBar = new ActionBarController().Initialize();
            mView = new MainWindowView();
            mMitarbeiterverwaltung = new ReportingController().Initialize(mDatabaseName);//new MitarbeiterverwaltungController().Initialize(mActionBar, databaseName);//
            mViewModel = new MainWindowViewModel
            {
                Content = mMitarbeiterverwaltung,
                ActionBar = mActionBar,
                ZeigeMitarbeiterverwaltung = new RelayCommand(ZeigeMitarbeiterverwaltungExecute),
                ZeigeReporting = new RelayCommand(ZeigeReportingExecute),
                ZeigeArtikelverwaltung = new RelayCommand(ZeigeArtikelverwaltungExecute),
                ZeigeAuftragsverwaltung = new RelayCommand(ZeigeAuftragsverwaltungExecute)
            };
            mView.DataContext = mViewModel;
            mView.ShowDialog();
        }

        private void ZeigeMitarbeiterverwaltungExecute(object obj)
        {
            mViewModel.Content = new MitarbeiterverwaltungController().Initialize(mActionBar, mDatabaseName);
        }

        private void ZeigeAuftragsverwaltungExecute(object obj)
        {
            mViewModel.Content = new AuftragsverwaltungController().Initialize(mActionBar, mDatabaseName);
        }

        private void ZeigeReportingExecute(object obj)
        {
            mReporting = new ReportingController().Initialize(mDatabaseName);
            mViewModel.Content = mReporting;
            //mView.DataContext = mViewModel;
            //((MainWindowViewModel)mView.DataContext).Content = mReporting;
        }

        private void ZeigeArtikelverwaltungExecute(object obj)
        {
            mArtikelverwaltung = new ArtikelverwaltungController().Initialize(mActionBar, mDatabaseName);
            mViewModel.Content = mArtikelverwaltung;
        }

    }
}
