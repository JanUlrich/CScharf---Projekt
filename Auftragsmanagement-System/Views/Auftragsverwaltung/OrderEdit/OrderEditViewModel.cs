using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auftragsmanagement_System.Framework;
using Auftragsmanagement_System.Models;

namespace Auftragsmanagement_System.Views.Auftragsverwaltung.OrderEdit
{
    class OrderEditViewModel : ViewModelBase
    {
        private Employee verkäufer;
        

        public Employee Verkäufer
        {
            get { return verkäufer; }
            set
            {
                if (verkäufer == value) return;
                verkäufer = value;
                OnPropertyChanged("Verkäufer");
            }
        }
    }
}
