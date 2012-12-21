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

namespace Auftragsmanagement_System.Views.Auftragsverwaltung.ViewModel
{
    class AuftragsverwaltungViewModel : ViewModelBase
    {
        private ObservableCollection<CompleteOrder> orders;
        private CompleteOrder selectedOrder;
        private OrderLine selectedOrderLine;
        private UserControl editControl;

        private CollectionView employees;
        private CollectionView customers;
        private CollectionView articles;
        private OrderLine orderLine;



        public CollectionView Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                OnPropertyChanged("Employees");
            }
        }

        public OrderLine OrderLine
        {
            get { return orderLine; }
            set
            {
                orderLine = value;
                OnPropertyChanged("OrderLine");
            }
        }
        public ObservableCollection<CompleteOrder> Orders
        {
            get { return orders; }
            set { orders = value; 
            OnPropertyChanged("Orders");}
        }

        public CompleteOrder SelectedOrder
        {
            get { return selectedOrder; }
            set { selectedOrder = value; 
            OnPropertyChanged("SelectedOrder");}
        }

        public UserControl EditControl
        {
            get { return editControl; }
            set { editControl = value; 
            OnPropertyChanged("EditControl");}
        }

        public OrderLine SelectedOrderLine
        {
            get { return selectedOrderLine; }
            set { selectedOrderLine = value; 
            OnPropertyChanged("SelectedOrderLine");}
        }

        public CollectionView Customers
        {
            get { return customers; }
            set { customers = value;
            OnPropertyChanged("Customers");}
        }

        public CollectionView Articles
        {
            get { return articles; }
            set { articles = value; 
            OnPropertyChanged("Articles");}
        }
    }
}
