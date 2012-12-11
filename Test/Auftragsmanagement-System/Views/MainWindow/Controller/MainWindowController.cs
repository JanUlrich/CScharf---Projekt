using System.Collections.ObjectModel;
using System.Windows.Controls;
using Auftragsmanagement_System.Framework;
using Auftragsmanagement_System.MainWindow.View;
using Auftragsmanagement_System.Mitarbeiterverwaltung.Controller;
using Auftragsmanagement_System.Mitarbeiterverwaltung.View;
using Auftragsmanagement_System.Models;
using Auftragsmanagement_System.Views.ActionBar.Controller;
using Auftragsmanagement_System.Views.ActionBar.View;
using Auftragsmanagement_System.Views.MainWindow.ViewModel;
using Uebung_12.Framework;

namespace Auftragsmanagement_System.Views.MainWindow.Controller
{
    class MainWindowController
    {
        private ActionBarView ActionBar;
        public void Initialize()
        {
            ActionBar = new ActionBarController().Initialize();
            var view = new MainWindowView();
            var mViewModel = new MainWindowViewModel
            {
                Content = new MitarbeiterverwaltungController().Initialize(ActionBar),
                ActionBar = ActionBar
            };
            view.DataContext = mViewModel;
            view.ShowDialog();
        }
    }
}
