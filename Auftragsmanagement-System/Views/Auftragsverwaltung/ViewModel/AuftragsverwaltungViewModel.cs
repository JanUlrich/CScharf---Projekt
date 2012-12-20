using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Auftragsmanagement_System.Framework;
using Auftragsmanagement_System.Models;

namespace Auftragsmanagement_System.Views.Auftragsverwaltung.ViewModel
{
    class AuftragsverwaltungViewModel : ViewModelBase
    {
        private ObservableCollection<CompleteOrder> orders;
        private CompleteOrder selectedOrder;
        private UserControl editControl;

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
            set { editControl = value; }
        }
    }
}
