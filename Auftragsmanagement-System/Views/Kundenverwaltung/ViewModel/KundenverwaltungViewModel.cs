using System.Collections.ObjectModel;
using System.Windows.Input;
using Auftragsmanagement_System.Framework;
using Auftragsmanagement_System.Models;

namespace Auftragsmanagement_System.Kundenverwaltung2.ViewModel
{
    class KundenverwaltungViewModel : ViewModelBase
    {
        private ObservableCollection<Customer> mModels;
        private Customer mSelectedModel;

        public Customer SelectedModel
        {
            get { return mSelectedModel; }
            set
            {
                if (mSelectedModel == value) return;
                mSelectedModel = value;
                OnPropertyChanged("SelectedModel");
            }
        }

        public ObservableCollection<Customer> Models
        {
            get { return mModels; }
            set
            {
                if (mModels == value) return;
                mModels = value;
                OnPropertyChanged("Models");
            }
        }



    }
}
