using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using HOAHome.Code.EntityFramework;

namespace HOAHome.Repositories
{
    [ContractClass(typeof(IRepositoryBaseContract<>))]
    public interface IRepositoryBase<T> where T : IEntity
    {
        T Get(Guid id);
        IList<T> GetAll();
        void Delete(Guid id);
        void SaveChanges();
    }
    [ContractClassFor(typeof(IRepositoryBase<>))]
    sealed class IRepositoryBaseContract<T> : IRepositoryBase<T> where T : IEntity
    {
        T IRepositoryBase<T>.Get(Guid id)
        {
            Contract.Requires(id != Guid.Empty);
            return default(T);
        }

        IList<T> IRepositoryBase<T>.GetAll()
        {
            throw new NotImplementedException();
        }

        void IRepositoryBase<T>.Delete(Guid id)
        {
            Contract.Requires(id != Guid.Empty);
        }

        void IRepositoryBase<T>.SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}