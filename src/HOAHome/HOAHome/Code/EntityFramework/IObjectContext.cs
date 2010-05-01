using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Data.Objects;
using System.Data.Metadata.Edm;

namespace HOAHome.Code.EntityFramework
{
    [ContractClass(typeof(IObjectContextContract))]
    public interface IObjectContext : IDisposable
    {
        int SaveChanges();
        void DeleteObject(object obj);

        ObjectQuery<T> CreateQuery<T>(string p, params ObjectParameter[] parameters);

        void AddObject(string p, object obj);
        MetadataWorkspace MetadataWorkspace { get; }
        string DefaultContainerName { get; }
        ObjectStateManager ObjectStateManager { get; }
        void Refresh(RefreshMode refreshMode, object entity);
        void ApplyPropertyChanges(string entitySetName, object entity);
        ObjectResult<TElement> ExecuteStoreQuery<TElement>(string commandText, params object[] parameters);

        ObjectResult<TEntity> ExecuteStoreQuery<TEntity>(string commandText, string entitySetName,
                                                                MergeOption mergeOption, params object[] parameters);
    }
    [ContractClassFor(typeof(IObjectContext))]
    sealed class IObjectContextContract : IObjectContext

{
        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        int IObjectContext.SaveChanges()
        {
            throw new NotImplementedException();
        }

        void IObjectContext.DeleteObject(object obj)
        {
            throw new NotImplementedException();
        }

        ObjectQuery<T> IObjectContext.CreateQuery<T>(string p, params ObjectParameter[] parameters)
        {
            //Contract.Ensures(Contract.Result<ObjectQuery<T>>() != null);
            return default(ObjectQuery<T>);
        }

        void IObjectContext.AddObject(string p, object obj)
        {
            throw new NotImplementedException();
        }

        public MetadataWorkspace MetadataWorkspace
        {
            get { throw new NotImplementedException(); }
        }

        string IObjectContext.DefaultContainerName
        {
            get { throw new NotImplementedException(); }
        }

        ObjectStateManager IObjectContext.ObjectStateManager
        {
            get { throw new NotImplementedException(); }
        }

        void IObjectContext.Refresh(RefreshMode refreshMode, object entity)
        {
            throw new NotImplementedException();
        }

        void IObjectContext.ApplyPropertyChanges(string entitySetName, object entity)
        {
            throw new NotImplementedException();
        }

        ObjectResult<TElement> IObjectContext.ExecuteStoreQuery<TElement>(string commandText, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        ObjectResult<TEntity> IObjectContext.ExecuteStoreQuery<TEntity>(string commandText, string entitySetName, MergeOption mergeOption, params object[] parameters)
        {
            throw new NotImplementedException();
        }
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.MetadataWorkspace != null);
            
        }
}
}