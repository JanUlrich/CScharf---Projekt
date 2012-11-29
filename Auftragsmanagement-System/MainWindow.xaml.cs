using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Auftragsmanagement_System.Framework;
using Auftragsmanagement_System.Models;

namespace Auftragsmanagement_System
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var mCustomerRepository = new Repository<Employee>(@"F:\AndiStuff\Visual Studio Workspace\Auftragsmanagement-System\Auftragsmanagement-System\Database\CompanyManagementSystem.db"); //TODO: hier den absoluten Verweis ersetzen
            foreach (var test in mCustomerRepository.GetAll())
            {
                textBox.Text = textBox.Text + "\n"+ test.Address.Street;
            }
        }
    }
}
