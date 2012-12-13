using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using Auftragsmanagement_System.Framework;
using Auftragsmanagement_System.Models;
using Auftragsmanagement_System.Views.MainWindow.Controller;

namespace Auftragsmanagement_System
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var path = Assembly.GetExecutingAssembly().Location + @"Database\CompanyManagementSystem.db"; //TODO: Das hier tut net... ist nicht der absolute Pfad sonder der Pfad zur exe

            

            base.OnStartup(e);
            string databaseName = path;
            new MainWindowController().Initialize(databaseName);
        }
    }
}
