using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using HOAHome.Code.ContentManagement;
using HOAHome.Code.EntityFramework;
using HOAHome.Models;

namespace HOAHome.Repositories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IPersistanceFramework _persistance = new PersistanceFramework(new COHHomeEntities());
        public INeighborhoodRepository Neighborhood
        {
            get
            {
                return new NeighborhoodRepository(_persistance);
            }
        }

        public IHomeRepository Home
        {
            get { return new HomeRepository(this._persistance); }
           
        }

        public IContentRepository ContentRepository(Guid nhid)
        {
            //Contract.Ensures(this._contentRepository != null);

               
                 return  new ContentRepository(nhid,
                                         this._persistance);
               
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this._persistance != null);
        }
    }
}