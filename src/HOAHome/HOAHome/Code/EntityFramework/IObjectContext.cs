using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Objects;
using System.Data.Metadata.Edm;

namespace HOAHome.Code.EntityFramework
{
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
}