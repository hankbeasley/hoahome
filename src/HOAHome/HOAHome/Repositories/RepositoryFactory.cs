using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HOAHome.Code.EntityFramework;
using HOAHome.Models;

namespace HOAHome.Repositories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private IPersistanceFramework _persistance = new PersistanceFramework(new COHHomeEntities());
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
    }
}