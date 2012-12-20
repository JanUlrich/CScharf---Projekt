using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml.Serialization;
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
using Microsoft.Win32;
using Uebung_12.Framework;

namespace Auftragsmanagement_System.Views.Artikelverwaltung.Controller
{
    class ArtikelverwaltungController
    {
        private Repository<Article> mArticleRepository;
        private ArtikelverwaltungViewModel mViewModel;
        private string mDatabaseName;

        public UserControl Initialize(ActionBarView actionBar, string databaseName)
        {
            mDatabaseName = databaseName;
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
                Command4 = new RelayCommand(ImportCommandExecute),
                Command1Text = "Neu",
                Command2Text = "Löschen",
                Command3Text = "Speichern",
                Command4Text = "Importieren"
            };

            return view;
        }
        private void AddCommandExecute(object obj)
        {
            var art = new Article();

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
            string Pfad = string.Empty;
            Article import;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            Nullable<bool> result = openFileDialog1.ShowDialog();
            if (result.Value == true){
                Pfad = openFileDialog1.FileName;
                //mViewModel.SelectedArticle = ImportiereAuftrag(Pfad);
                import = ImportiereAuftrag(Pfad);
            
            var rep = new Repository<Article>(mDatabaseName).GetAll();
            if (rep.Contains(import))
            {
                MessageBox.Show("Artikel mit Artikelnummer: " + import.ArticleNumber +
                                " ist bereits vorhanden");
            }
            else
            {
                mViewModel.Articles.Add(import);
                mArticleRepository.Save(import);
            }
            }
        }

        private Article ImportiereAuftrag(string file)
        {
            Article article;
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof (Article));
            using (var stream = new FileStream(file, FileMode.Open))
            {
                article = serializer.Deserialize(stream) as Article;
            }
            return article;
        }

        private bool ArticleNumberIsUnique(string artNum)
        {
            var mArticles = mArticleRepository.GetAll();
            return mArticles.Find((art) => (art.ArticleNumber.Equals(artNum))) == null;           
        }

    }
}
