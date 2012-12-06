using System.Windows.Controls;
using Auftragsmanagement_System.Views.ActionBar.View;
using Auftragsmanagement_System.Views.ActionBar.ViewModel;

namespace Auftragsmanagement_System.Views.ActionBar.Controller
{
    class ActionBarController
    {
        public ActionBarView Initialize()
        {
            ActionBarView ActionBarView = new ActionBarView();
            ActionBarView.DataContext = new ActionBarViewModel
                                            {
                                                //Es wird eine Aktionslose ActionBar Initialisiert...
                                            };
            return ActionBarView;
        }
    }
}
