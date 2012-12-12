using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Auftragsmanagement_System.Framework;
using Auftragsmanagement_System.Mitarbeiterverwaltung.View;
using Auftragsmanagement_System.Mitarbeiterverwaltung.ViewModel;
using Auftragsmanagement_System.Models;
using Auftragsmanagement_System.Views.ActionBar.View;
using Auftragsmanagement_System.Views.ActionBar.ViewModel;
using Auftragsmanagement_System.Views.Artikelverwaltung.View;
using Auftragsmanagement_System.Views.Artikelverwaltung.ViewModel;
using Uebung_12.Framework;

namespace Auftragsmanagement_System.Views.Artikelverwaltung.Controller
{
    class ArtikelverwaltungController
    {
        private Repository<Article> mArticleRepository;
        private ArtikelverwaltungViewModel mViewModel;

        public UserControl Initialize(ActionBarView actionBar, string databaseName)
        {
            UserControl view = new ArtikelverwaltungView();

            mArticleRepository =
                new Repository<Article>(
                    databaseName);

            mViewModel = new ArtikelverwaltungViewModel()
            {
                Articles = new ObservableCollection<Article>(mArticleRepository.GetAll()),
                SelectedArticle = null
            };
            view.DataContext = mViewModel;

            actionBar.DataContext = new ActionBarViewModel
            {
                Command1 = new RelayCommand(AddCommandExecute),
                Command2 = new RelayCommand(DeleteCommandExecute, DeleteCommandCanExecute),
                Command3 = new RelayCommand(SaveCommandExecute, SaveCommandCanExecute),
                Command1Text = "Neu",
                Command2Text = "Löschen",
                Command3Text = "Speichern"
            };

            return view;
        }
        private void AddCommandExecute(object obj)
        {
            var art = new Article();

            var mArticles = mArticleRepository.GetAll();
            mArticles.Sort((a1, a2) => a2.ArticleNumber.CompareTo(a1.ArticleNumber));
            if (mArticles.Count > 0) { art.ArticleNumber = ""+Convert.ToInt32(mArticles[0].ArticleNumber) + 1; }
            else
            {
                art.ArticleNumber = "1";
            }

            mViewModel.SelectedArticle = art;
            mViewModel.Articles.Add(mViewModel.SelectedArticle);
        }

        private void DeleteCommandExecute(object obj)
        {
            mArticleRepository.Delete(mViewModel.SelectedArticle);
        }
        private bool DeleteCommandCanExecute(object obj)
        {
            return mViewModel.SelectedArticle != null;
        }

        private void SaveCommandExecute(object obj)
        {
            mArticleRepository.Save(mViewModel.SelectedArticle);
        }
        private bool SaveCommandCanExecute(object obj)
        {
            return mViewModel.SelectedArticle != null;
        }

        private void ImportCommandExecute(object obj)
        {
            
        }

        private void ImportiereAuftrag(string file)
        {
            
        }

    }
}
