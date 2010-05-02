using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
            Contract.Requires<ArgumentNullException>(persistance != null);
            _persistance = persistance;
        }

        private readonly IPersistanceFramework _persistance;

        protected IPersistanceFramework Persistance
        {
            get
            {
                Contract.Ensures(Contract.Result<IPersistanceFramework>() != null);
                Contract.Assume(_persistance!=null);
                return _persistance;
            }
            //private set { _persistance = value; }
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