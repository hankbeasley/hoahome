using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HOAHome.Code.EntityFramework;

namespace HOAHome.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : IEntity
    {
        //private IPersistanceFramework _persistance;

        public RepositoryBase(IPersistanceFramework persistance)
        {
            Persistance = persistance;
        }

        protected IPersistanceFramework Persistance
        { 
            get;
            private set;
        }

        public T Get(Guid id)
        {
            return this.Persistance.Get<T>(id);
        }
        public IList<T> GetAll()
        {
            return this.Persistance.CreateQueryContext<T>().ToList().AsReadOnly();
        }

        public void Delete(Guid id)
        {
            this.Persistance.Delete<T>(id);
        }

        public void SaveChanges()
        {
            this.Persistance.SaveChanges();
        }
    }
}