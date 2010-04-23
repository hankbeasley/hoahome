using System;
namespace HOAHome.Code.EntityFramework
{
    public interface IPersistanceFramework
    {
        T AttachNew<T>(T entity) where T : IEntity;
        T Create<T>() where T : IEntity, new();
        System.Linq.IQueryable<T> CreateQueryContext<T>(params string[] includes) where T : IEntity;
        void Delete<T>(Guid id) where T : IEntity;
        T Get<T>(Guid id, params string[] includes) where T : IEntity;
        void SaveChanges();
    }
}
