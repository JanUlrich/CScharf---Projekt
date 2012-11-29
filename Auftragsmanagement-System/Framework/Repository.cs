using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Auftragsmanagement_System.Framework
{
    class Repository<T> where T : class
    {
        public Repository(string databaseFile)
        {
            NHibernateHelper.DatabaseFile = databaseFile;
        }

        public List<T> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var returnList = session.CreateCriteria<T>().List<T>();
                return returnList as List<T>;
            }
        }

        public void Save(T entity)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                }
            }
        }

        public void Delete(T entity)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(entity);
                    transaction.Commit();
                }
            }
        }
    }
}
