using ProjectRepositoryPattern_DataLayer.Services;
using ProjectRepositoryPattern_ModelClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRepositoryPattern_DataLayer.Context
{
    public class UnitOfWork : IDisposable
    {
        ProjectRepositoryPatternContext db = new ProjectRepositoryPatternContext();

        #region Person
        private MyGenericRepository<Person> personRepository;
        public MyGenericRepository<Person> PersonRepository
        {
            get
            {
                if (personRepository == null)
                {
                    personRepository = new MyGenericRepository<Person>(db);
                }
                return personRepository;
            }
        }
        #endregion

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
