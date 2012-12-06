using System.Windows.Input;
using Auftragsmanagement_System.Framework;

namespace Auftragsmanagement_System.Views.ActionBar.ViewModel
{
    class ActionBarViewModel : ViewModelBase
    {
        private ICommand _deleteCommand;
        private ICommand _addCommand;
        private ICommand _saveCommand;

        public ICommand AddCommand
        {
            get { return _addCommand; }
            set { _addCommand = value; }
        }

        public ICommand DeleteCommand
        {
            get { return _deleteCommand; }
            set { _deleteCommand = value; }
        }

        public ICommand SaveCommand
        {
            get { return _saveCommand; }
            set { _saveCommand = value; }
        }
    }
}
