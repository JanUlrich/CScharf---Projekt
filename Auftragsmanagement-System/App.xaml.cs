using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
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
            base.OnStartup(e);
            string databaseName =
                @"F:\AndiStuff\Visual Studio Workspace\Auftragsmanagement-System\Auftragsmanagement-System\Database\CompanyManagementSystem.db";
            new MainWindowController().Initialize(databaseName);
        }
    }
}
