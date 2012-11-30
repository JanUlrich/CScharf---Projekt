using System.Collections.ObjectModel;
using System.Windows.Controls;
using Auftragsmanagement_System.Framework;
using Auftragsmanagement_System.Mitarbeiterverwaltung.View;
using Auftragsmanagement_System.Mitarbeiterverwaltung.ViewModel;
using Auftragsmanagement_System.Models;
using Uebung_12.Framework;

namespace Auftragsmanagement_System.Mitarbeiterverwaltung.Controller
{
    internal class MitarbeiterverwaltungController
    {

        private MitarbeiterverwaltungViewModel mViewModel;
        private Repository<Employee> mEmployeeRepository;

        public UserControl Initialize()
        {
            UserControl view = new MitarbeiterverwaltungView();
            mEmployeeRepository =
                new Repository<Employee>(
                    @"F:\AndiStuff\Visual Studio Workspace\Auftragsmanagement-System\Auftragsmanagement-System\Database\CompanyManagementSystem.db");
                //TODO: hier den absoluten Verweis ersetzen

            mViewModel = new MitarbeiterverwaltungViewModel
                             {
                                 Models = new ObservableCollection<Employee>(mEmployeeRepository.GetAll()),
                             };
            view.DataContext = mViewModel;
            return view;
        }

    }
}