using System.Windows;
using System.Windows.Input;
using Auftragsmanagement_System.Framework;

namespace Auftragsmanagement_System.Views.ActionBar.ViewModel
{
    class ActionBarViewModel : ViewModelBase
    {
        private ICommand _Command1;
        private ICommand _Command2;
        private ICommand _Command3;
        private ICommand _Command4;
        private ICommand _Command5;

        private string _Command1Text;
        private string _Command2Text;
        private string _Command3Text;
        private string _Command4Text;
        private string _Command5Text;

        private Visibility _Command1Show = Visibility.Hidden;
        private Visibility _Command2Show = Visibility.Hidden;
        private Visibility _Command3Show = Visibility.Hidden;
        private Visibility _Command4Show = Visibility.Hidden;
        private Visibility _Command5Show = Visibility.Hidden;

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
            set { _Command1Text = value;
            Command1Show = Visibility.Visible;
            }
        }

        public string Command2Text
        {
            get { return _Command2Text; }
            set { _Command2Text = value; Command2Show = Visibility.Visible; }
        }

        public string Command3Text
        {
            get { return _Command3Text; }
            set { _Command3Text = value; Command3Show = Visibility.Visible; }
        }

        public ICommand Command4
        {
            get { return _Command4; }
            set { _Command4 = value;  }
        }

        public string Command4Text
        {
            get { return _Command4Text; }
            set { _Command4Text = value; Command4Show = Visibility.Visible; }
        }

        public Visibility Command1Show
        {
            get { return _Command1Show; }
            set { _Command1Show = value; }
        }

        public Visibility Command2Show
        {
            get { return _Command2Show; }
            set { _Command2Show = value; }
        }

        public Visibility Command3Show
        {
            get { return _Command3Show; }
            set { _Command3Show = value; }
        }

        public Visibility Command4Show
        {
            get { return _Command4Show; }
            set { _Command4Show = value; }
        }

        public Visibility Command5Show
        {
            get { return _Command5Show; }
            set { _Command5Show = value; }
        }

        public ICommand Command5
        {
            get { return _Command5; }
            set { _Command5 = value; }
        }

        public string Command5Text
        {
            get { return _Command5Text; }
            set { _Command5Text = value; Command5Show = Visibility.Visible; }
        }
    }
}
