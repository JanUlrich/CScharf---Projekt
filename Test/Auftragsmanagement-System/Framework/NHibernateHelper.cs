using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Auftragsmanagement_System.Framework
{
    public class NHibernateHelper
    {
        private static ISessionFactory mSessionFactory;
        private static string _databaseFile;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (mSessionFactory == null)
                    InitializeSessionFactory();
                return mSessionFactory;
            }
        }

        public static string DatabaseFile
        {
            get { return _databaseFile; }
            set { _databaseFile = value; }
        }
        
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private static void InitializeSessionFactory()
        {
            mSessionFactory = Fluently.Configure()
            .Database(SQLiteConfiguration.Standard.UsingFile(DatabaseFile).ShowSql())
            .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())
            .Conventions.Add(FluentNHibernate.Conventions.Helpers.DefaultLazy.Never()))
            .BuildSessionFactory();
        }
    }
}
