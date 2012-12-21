using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Auftragsmanagement_System.Framework;
using Auftragsmanagement_System.Models;
using Auftragsmanagement_System.Views.ActionBar.View;
using Auftragsmanagement_System.Views.ActionBar.ViewModel;
using Auftragsmanagement_System.Views.Auftragsverwaltung.OrderEdit.View;
using Auftragsmanagement_System.Views.Auftragsverwaltung.ViewModel;


namespace Auftragsmanagement_System.Views.Auftragsverwaltung.OrderEdit.Controller
{
    internal class OrderEditControl
    {
        private string mDatabaseName;
        private AuftragsverwaltungViewModel mViewModel;
        private Repository<Employee> mEmployeeRepository;


        public OrderEditView Initialize(ActionBarView actionBar, string databaseName, AuftragsverwaltungViewModel viewModel)
        {
            mDatabaseName = databaseName;
            mEmployeeRepository = new Repository<Employee>(mDatabaseName);

            mViewModel = viewModel;

            OrderEditView ret = new OrderEditView();
            ret.DataContext = mViewModel;

            actionBar.DataContext = new ActionBarViewModel
                                        {

                                        };

            ret.InitializeComponent();

            return ret;
        }

    }
}
