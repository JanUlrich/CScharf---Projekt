using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auftragsmanagement_System.Models;

namespace Auftragsmanagement_System.Views.Artikelverwaltung.ViewModel
{
    class ArtikelverwaltungViewModel
    {
        private ObservableCollection<Article> mArticles;
        private Article mSelectedArticle;

        public Article SelectedArticle
        {
            get { return mSelectedArticle; }
            set { mSelectedArticle = value; }
        }

        public ObservableCollection<Article> Articles
        {
            get { return mArticles; }
            set { mArticles = value; }
        }
    }
}
