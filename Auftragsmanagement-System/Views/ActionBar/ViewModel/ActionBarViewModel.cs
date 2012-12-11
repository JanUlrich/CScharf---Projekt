using System.Windows.Input;
using Auftragsmanagement_System.Framework;

namespace Auftragsmanagement_System.Views.ActionBar.ViewModel
{
    class ActionBarViewModel : ViewModelBase
    {
        private ICommand _Command1;
        private ICommand _Command2;
        private ICommand _Command3;

        private string _Command1Text;
        private string _Command2Text;
        private string _Command3Text;


        public ICommand Command3
        {
            get { return _Command3; }
            set { _Command3 = value; }
        }

        public ICommand Command2
        {
            get { return _Command2; }
            set { _Command2 = value; }
        }

        public ICommand Command1
        {
            get { return _Command1; }
            set { _Command1 = value; }
        }

        public string Command1Text
        {
            get { return _Command1Text; }
            set { _Command1Text = value; }
        }

        public string Command2Text
        {
            get { return _Command2Text; }
            set { _Command2Text = value; }
        }

        public string Command3Text
        {
            get { return _Command3Text; }
            set { _Command3Text = value; }
        }
    }
}
