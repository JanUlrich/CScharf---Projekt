using System.Collections.ObjectModel;
using System.Windows.Input;
using Auftragsmanagement_System.Framework;
using Auftragsmanagement_System.Models;

namespace Auftragsmanagement_System.Mitarbeiterverwaltung.ViewModel
{
    class MitarbeiterverwaltungViewModel : ViewModelBase
    {
        private ObservableCollection<Employee> mModels;
        private Employee mSelectedModel;

        public Employee SelectedModel
        {
            get { return mSelectedModel; }
            set
            {
                if (mSelectedModel == value) return;
                mSelectedModel = value;
                OnPropertyChanged("SelectedModel");
            }
        }

        public ObservableCollection<Employee> Models
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
