using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Auftragsmanagement_System.Framework;
using Auftragsmanagement_System.Models;
using Auftragsmanagement_System.Views.ActionBar.Controller;
using Auftragsmanagement_System.Views.ActionBar.View;
using Auftragsmanagement_System.Views.Auftragsverwaltung.View;
using Auftragsmanagement_System.Views.Auftragsverwaltung.ViewModel;

namespace Auftragsmanagement_System.Views.Auftragsverwaltung.Controller
{
    class AuftragsverwaltungController
    {
        private List<CompleteOrder> mCompleteOrders;
        private AuftragsverwaltungViewModel mViewModel;
        private string mDatabaseName;
        private Repository<Order> mOrderRepository;
        private Repository<OrderLine> mOrderlineRepository; 


        public UserControl Initialize(ActionBarView actionBar, string databaseName)
        {
            mDatabaseName = databaseName;
            UserControl ret = new AuftragsverwaltungView();

            mViewModel = new AuftragsverwaltungViewModel
                             {
                             };

            AktualisiereAnzeige();


            ret.DataContext = mViewModel;

            return ret;
        }

        private void AktualisiereAnzeige()
        {
            mOrderRepository = new Repository<Order>(mDatabaseName);
            mOrderlineRepository = new Repository<OrderLine>(mDatabaseName);
            mCompleteOrders = CompleteOrder.GeneriereOrders(mOrderRepository.GetAll(), mOrderlineRepository.GetAll());
            Anzeigen(mCompleteOrders);
        }

        private void Anzeigen(List<CompleteOrder> orders)
        {
            mViewModel.Orders = new ObservableCollection<CompleteOrder>(orders);
        }
    }
}
