using System;
using System.Data.Objects;

namespace HOAHome.Code.EntityFramework
{
    public interface IPersistanceFramework
    {
        T AttachNew<T>(T entity) where T : IEntity;
        T Create<T>() where T : IEntity, new();
        System.Linq.IQueryable<T> CreateQueryContext<T>(params string[] includes) where T : IEntity;
        void Delete<T>(Guid id) where T : IEntity;
        T Get<T>(Guid id, params string[] includes) where T : IEntity;
        ObjectResult<TElement> ExecuteStoreQuery<TElement>(string commandText, params object[] parameters);

        ObjectResult<TEntity> ExecuteStoreQuery<TEntity>(string commandText, string entitySetName,
                                                                MergeOption mergeOption, params object[] parameters);
        void SaveChanges();
    }
}
