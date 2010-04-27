using System;
using System.Collections.Generic;
using HOAHome.Code.EntityFramework;

namespace HOAHome.Repositories
{
    public interface IRepositoryBase<T> where T : IEntity
    {
        T Get(Guid id);
        IList<T> GetAll();
        void Delete(Guid id);
        void SaveChanges();
    }
}