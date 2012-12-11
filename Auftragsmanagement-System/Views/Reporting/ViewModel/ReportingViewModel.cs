using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auftragsmanagement_System.Models;

namespace Auftragsmanagement_System.Views.Reporting.ViewModel
{
    class ReportingViewModel
    {
        private ObservableCollection<Article> topArtikel;

        public ObservableCollection<Article> TopArtikel
        {
            get { return topArtikel; }
            set { topArtikel = value; }
        }
    }
}
