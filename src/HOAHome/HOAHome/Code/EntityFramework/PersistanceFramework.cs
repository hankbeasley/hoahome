using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Data.Metadata.Edm;
using System.Data.Objects;

namespace HOAHome.Code.EntityFramework
{
    public class PersistanceFramework : IDisposable, IPersistanceFramework
    {
        private readonly IObjectContext _context;
        private readonly EntityContainer _eContainer;
        public PersistanceFramework(IObjectContext context) 
        {
            Contract.Requires(context != null);
           // Contract.Requires(context.MetadataWorkspace != null);
            Contract.Ensures(this._eContainer != null);
            Contract.Assume(context.MetadataWorkspace != null);
            this._context = context;
            this._eContainer = _context.MetadataWorkspace.GetEntityContainer(this._context.DefaultContainerName, DataSpace.CSpace);
            if (this._eContainer == null)
            {
                throw new ApplicationException();
            }
            if (this._eContainer.BaseEntitySets == null)
            {
                throw new ArgumentNullException();
            }
        }

        public T AttachNew<T>(T entityToAttach) where T : class,IEntity
        {
            _context.AddObject(GetEntitySet(typeof(T)), entityToAttach);
            entityToAttach = InitalizeEntity(entityToAttach);
            Contract.Assume(entityToAttach != null);
            return entityToAttach;
        }

        private static T InitalizeEntity<T>(T entity) where T : IEntity
        {
            //Contract.Ensures(Contract.Result<T>().Id != Guid.Empty);
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

        private string GetEntitySet(Type t)
        {
            Contract.Requires(t!=null);

            Type baseEntityType = GetEntityBaseType(t);
            if (this._eContainer.BaseEntitySets == null)
            {
                throw new ApplicationException();
            }
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
            Contract.Requires(t != null);
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
            var baseQuery = _context.CreateQuery<T>(GetEntitySet(typeof (T)));
            Contract.Assume(baseQuery != null);
            ObjectQuery<T> query = ((ObjectQuery<T>)AddOfType(baseQuery)).Where("it.Id = @p", param);
            Contract.Assume(query != null);
            var finalQuery = AddIncludes(query, includes);
            if (finalQuery.Count() == 0)
            {
                throw new ApplicationException(string.Format("Could not load {0}:{1}", typeof(T).Name, id));
            }
            var entity = finalQuery.First();
            Contract.Assume(entity.Id != Guid.Empty);
            return entity;
        }
        public void Delete<T>(Guid id) where T : IEntity
        {
            var entity = this.Get<T>(id);
            this._context.DeleteObject(entity);
        }
        public void Delete<T>(T entity) where T : class, IEntity
        {
            this._context.DeleteObject(entity);
        }

        private static IQueryable<T> AddIncludes<T>(IQueryable<T> query, params string[] includes) where T : IEntity
        {
            Contract.Requires(query != null);
            Contract.Requires(includes != null);
            Contract.Ensures(Contract.Result<IQueryable<T>>() != null);

            foreach (string include in includes)
            {
                query = ((ObjectQuery<T>)query).Include(include);
            }
            if (query == null) throw new ApplicationException();
            return query;
        }
        private IQueryable<T> AddOfType<T>(IQueryable<T> query) where T : IEntity
        {
            Contract.Requires(query!=null);
            Contract.Ensures(Contract.Result<IQueryable<T>>() != null);
            if (typeof(T) != this.GetEntityBaseType(typeof(T)))
            {
                var result = ((ObjectQuery<T>)query).OfType<T>();
                if (result == null) throw new ApplicationException();
                return result;
            }
            
            return query;
        }
        public IQueryable<T> CreateQueryContext<T>(params string[] includes) where T : IEntity
        {
            var baseQuery = this._context.CreateQuery<T>(GetEntitySet(typeof (T)));
            Contract.Assume(baseQuery !=null);
            return AddOfType(AddIncludes(baseQuery, includes));
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        

        public T Create<T>() where T : class, IEntity, new()
        {
            return AttachNew(new T());
        }


        public ObjectResult<TElement> ExecuteStoreQuery<TElement>(string commandText, params object[] parameters)
        {
            var result = this._context.ExecuteStoreQuery<TElement>(commandText, parameters);
            Contract.Assume(result != null);
            return result;
        }

        public ObjectResult<TEntity> ExecuteStoreQuery<TEntity>(string commandText, string entitySetName, MergeOption mergeOption, params object[] parameters)
        {
            var result =  this._context.ExecuteStoreQuery<TEntity>(commandText,entitySetName, mergeOption, parameters);
            Contract.Assume(result != null);
            return result;
        }
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this._context != null);
            Contract.Invariant(this._eContainer != null);
        }
    }
}