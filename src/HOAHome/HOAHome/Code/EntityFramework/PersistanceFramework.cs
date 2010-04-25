using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Metadata.Edm;
using System.Data.Objects;

namespace HOAHome.Code.EntityFramework
{
    public class PersistanceFramework : IDisposable, IPersistanceFramework
    {
        private IObjectContext _context;
        private EntityContainer _eContainer;
        public PersistanceFramework(IObjectContext context) 
        {
            this._context = context;
            this._eContainer = _context.MetadataWorkspace.GetEntityContainer(this._context.DefaultContainerName, DataSpace.CSpace);
       
        }

        public T AttachNew<T>(T entityToAttach) where T : IEntity
        {
            _context.AddObject(GetEntitySet(typeof(T)), entityToAttach);
            InitalizeEntity(entityToAttach);
            return entityToAttach;
        }

        private T InitalizeEntity<T>(T entity) where T : IEntity
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }
            if (entity is IAuditable)
            {
                var auditable = (IAuditable)entity;
                auditable.CreatedDate = DateTime.Now;
                auditable.ModifiedDate = auditable.CreatedDate;
                auditable.CreatedBy = System.Threading.Thread.CurrentPrincipal.Identity.Name;
                auditable.ModifiedBy = System.Threading.Thread.CurrentPrincipal.Identity.Name;
            }
            return entity;
        }

        public void SaveChanges()
        {
            foreach (ObjectStateEntry objectState in _context.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Modified))
            {
                if (objectState.Entity is IAuditable)
                {
                    var auditable = (IAuditable)objectState.Entity;
                    auditable.ModifiedDate = DateTime.Now;
                    auditable.ModifiedBy = System.Threading.Thread.CurrentPrincipal.Identity.Name;
                }
            }
            _context.SaveChanges();
        }

        public string GetEntitySet(Type t)
        {
            Type baseEntityType = GetEntityBaseType(t);
            var entitySets = (from e in this._eContainer.BaseEntitySets
                              where e.ElementType.Name == baseEntityType.Name
                              select e);
            if (entitySets.Count() == 0)
            {
                throw new InvalidOperationException(string.Format("Could not find an entity set for this type({0}) Are you sure you have created the right model definition?", t));
            }
            return entitySets.First().Name;
        }
        private Type GetEntityBaseType(Type t)
        {
            if (t.BaseType == typeof(System.Data.Objects.DataClasses.EntityObject))
            {
                return t;
            }
            else
            {
                return GetEntityBaseType(t.BaseType);
            }
        }
        public T Get<T>(Guid id, params string[] includes) where T : IEntity
        {
            ObjectParameter param = new ObjectParameter("p", id);
            ObjectQuery<T> query = ((ObjectQuery<T>)AddOfType(_context.CreateQuery<T>(GetEntitySet(typeof(T))))).Where("it.Id = @p", param);
            var finalQuery = AddIncludes(query, includes);
            if (finalQuery.Count() == 0)
            {
                throw new ApplicationException(string.Format("Could not load {0}:{1}", typeof(T).Name, id));
            }
            return finalQuery.First();
        }
        public void Delete<T>(Guid id) where T : IEntity
        {
            var entity = this.Get<T>(id);
            this._context.DeleteObject(entity);

        }
        private static IQueryable<T> AddIncludes<T>(IQueryable<T> query, params string[] includes) where T : IEntity
        {
            foreach (string include in includes)
            {
                query = ((ObjectQuery<T>)query).Include(include);
            }
            return query;
        }
        private IQueryable<T> AddOfType<T>(IQueryable<T> query) where T : IEntity
        {
            if (typeof(T) != this.GetEntityBaseType(typeof(T)))
            {
                return ((ObjectQuery<T>)query).OfType<T>();
            }
            return query;
        }
        public IQueryable<T> CreateQueryContext<T>(params string[] includes) where T : IEntity
        {
            return AddOfType(AddIncludes(this._context.CreateQuery<T>(GetEntitySet(typeof(T))), includes));
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        

        public T Create<T>() where T : IEntity, new()
        {
            return AttachNew(new T());
        }


        public ObjectResult<TElement> ExecuteStoreQuery<TElement>(string commandText, params object[] parameters)
        {
            return this._context.ExecuteStoreQuery<TElement>(commandText, parameters);
        }

        public ObjectResult<TEntity> ExecuteStoreQuery<TEntity>(string commandText, string entitySetName, MergeOption mergeOption, params object[] parameters)
        {
            return this._context.ExecuteStoreQuery<TEntity>(commandText,entitySetName, mergeOption, parameters);
        }
    }
}