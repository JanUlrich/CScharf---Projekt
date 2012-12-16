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
        private string _fehlermeldung;

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

        public string Fehlermeldung
        {
            get { return _fehlermeldung; }
            set { _fehlermeldung = value; 
            OnPropertyChanged("Fehlermeldung");}
        }
    }
}
