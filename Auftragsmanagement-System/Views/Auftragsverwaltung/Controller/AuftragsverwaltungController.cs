using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using Auftragsmanagement_System.Framework;
using Auftragsmanagement_System.Models;
using Auftragsmanagement_System.Views.ActionBar.Controller;
using Auftragsmanagement_System.Views.ActionBar.View;
using Auftragsmanagement_System.Views.ActionBar.ViewModel;
using Auftragsmanagement_System.Views.Auftragsverwaltung.OrderEdit.Controller;
using Auftragsmanagement_System.Views.Auftragsverwaltung.View;
using Auftragsmanagement_System.Views.Auftragsverwaltung.ViewModel;
using Uebung_12.Framework;

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

            var orderEdit = new OrderEditControl();

            mViewModel = new AuftragsverwaltungViewModel
                             {
                                 Employees = new CollectionView(new Repository<Employee>(mDatabaseName).GetAll()),
                                 Customers = new CollectionView(new Repository<Customer>(mDatabaseName).GetAll()),
                                 Articles = new CollectionView(new Repository<Article>(mDatabaseName).GetAll())
                             };

            mViewModel.EditControl = orderEdit.Initialize(new ActionBarView(), mDatabaseName, mViewModel) as UserControl;

            actionBar.DataContext = new ActionBarViewModel
                                        {
                                            Command1Text = "Neuer Auftrag",
                                            Command1 = new RelayCommand(AddOrderExecute),
                                            Command2Text = "Neue Auftragsposition",
                                            Command2 = new RelayCommand(AddPositionExecute),
                                            Command3Text = "Änderungen Speichern",
                                            Command3 = new RelayCommand(SaveCommandExecute),
                                            Command5Text = "Position löschen",
                                            Command5 = new RelayCommand(DeletePositionExecute),
                                            Command4Text = "Auftrag löschen",
                                            Command4 = new RelayCommand(DeleteOrderExecute)
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

        private void AddOrderExecute(object obj)
        {
            var order = mViewModel.SelectedOrder.Order;
            var orders = mOrderRepository.GetAll();
            
            int orderNum = 1000;
            do
            {
                orderNum++;
                order.OrderNumber = order.OrderDate.Year + "-" + orderNum;

            } while (orders.Contains(order));

            
            //mOrderRepository.Save(order);                
            
        }
        private void AddPositionExecute(object obj)
        {
            var orderLine = new OrderLine();
            
            int orderPos = 100;
            do
            {
                orderPos+=100;
                orderLine.Position = orderPos;

            } while (mViewModel.SelectedOrder.Orderlines.TrueForAll((a)=>a.Position!=orderPos));

            mViewModel.SelectedOrder.Orderlines.Add(orderLine);
            orderLine.Order = mViewModel.SelectedOrder.Order;

            //mOrderlineRepository.Save(orderLine);
        }
        private void SaveCommandExecute(object obj)
        {
            mOrderRepository.Save(mViewModel.SelectedOrder.Order);
            mViewModel.SelectedOrder.Orderlines.ForEach((a)=>{mOrderlineRepository.Save(a);});
        }
        private void DeleteOrderExecute(object obj)
        {
            mViewModel.SelectedOrder.Orderlines.ForEach((a) => { mOrderlineRepository.Delete(a); });
            mOrderRepository.Delete(mViewModel.SelectedOrder.Order);

            mViewModel.SelectedOrderLine = null;
            mViewModel.SelectedOrder.OrderCollection = null;
            mViewModel.Orders.Remove(mViewModel.SelectedOrder);
            mViewModel.SelectedOrder = null;
        }
        private void DeletePositionExecute(object obj)
        {
            mOrderlineRepository.Delete(mViewModel.SelectedOrderLine);
            mViewModel.SelectedOrder.Orderlines.Remove(mViewModel.SelectedOrderLine);
            mViewModel.SelectedOrder.OrderCollection = mViewModel.SelectedOrder.OrderCollection;
            mViewModel.SelectedOrderLine = null;
        }
    }
}
