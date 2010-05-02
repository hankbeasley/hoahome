using System;
using System.Data.Objects;
using System.Diagnostics.Contracts;
using System.Linq;

namespace HOAHome.Code.EntityFramework
{
    [ContractClass(typeof(IPersistanceFrameworkContract))]
    public interface IPersistanceFramework
    {
        T AttachNew<T>(T entity) where T : class, IEntity;
        T Create<T>() where T : class,IEntity, new();
        System.Linq.IQueryable<T> CreateQueryContext<T>(params string[] includes) where T : IEntity;
        void Delete<T>(Guid id) where T : IEntity;
        T Get<T>(Guid id, params string[] includes) where T : IEntity;
        ObjectResult<TElement> ExecuteStoreQuery<TElement>(string commandText, params object[] parameters);

        ObjectResult<TEntity> ExecuteStoreQuery<TEntity>(string commandText, string entitySetName,
                                                                MergeOption mergeOption, params object[] parameters);
        void SaveChanges();
        void Delete<T>(T entity) where T : class, IEntity;

    }
    [ContractClassFor(typeof(IPersistanceFramework))]
    sealed class IPersistanceFrameworkContract : IPersistanceFramework
    {
        T IPersistanceFramework.AttachNew<T>(T entity)
        {
            Contract.Requires(entity != null);
            Contract.Ensures(Contract.Result<T>() != null);
           // Contract.Ensures(Contract.Result<T>().Id != Guid.Empty);
            return default(T);
        }

        T IPersistanceFramework.Create<T>()
        {
            Contract.Ensures(Contract.Result<T>() != null);
            return default(T);
        }

        IQueryable<T> IPersistanceFramework.CreateQueryContext<T>(params string[] includes)
        {
            Contract.Requires(includes != null);

            Contract.Ensures(null != Contract.Result<IQueryable<T>>());
            return default(IQueryable<T>);
        }

        void IPersistanceFramework.Delete<T>(Guid id)
        {
            Contract.Requires(id != Guid.Empty);
        }
         void IPersistanceFramework.Delete<T>(T entity)
        {
            Contract.Requires(entity != null);

        }
        T IPersistanceFramework.Get<T>(Guid id, params string[] includes)
        {
            Contract.Requires(includes != null);
            //Contract.Ensures(Contract.Result<T>().Id != Guid.Empty);
            return default(T);
        }

        ObjectResult<TElement> IPersistanceFramework.ExecuteStoreQuery<TElement>(string commandText, params object[] parameters)
        {
            Contract.Ensures(Contract.Result<ObjectResult<TElement>>() != null);
            return null;
        }

        ObjectResult<TEntity> IPersistanceFramework.ExecuteStoreQuery<TEntity>(string commandText, string entitySetName, MergeOption mergeOption, params object[] parameters)
        {
           // Contract.Ensures(Contract.Result<ObjectResult<TEntity>>() != null);
            return null;
        }

        void IPersistanceFramework.SaveChanges()
        {
            throw new NotImplementedException();
        }


       
    }
}
