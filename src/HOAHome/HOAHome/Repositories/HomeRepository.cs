using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HOAHome.Code.EntityFramework;
using HOAHome.Models;

namespace HOAHome.Repositories
{
    public class HomeRepository : RepositoryBase<Home>, IHomeRepository
    {
        public HomeRepository() : this(new PersistanceFramework(new COHHomeEntities()))
        {
        }

        public HomeRepository(IPersistanceFramework persistance) : base(persistance)
        {
        }
        public Home GetOrCreateHome(string addressFull, double latitude, double longitude)
        {
            var home = this.Persistance.CreateQueryContext<Home>().Where(h => h.AddressFull == addressFull).FirstOrDefault();
            if (home == null)
            {
                home = this.Persistance.Create<Home>();
                home.AddressFull = addressFull;
                home.Latitude = latitude;
                home.Longitude = longitude;
            }
            return home;
        }


        public void DeleteIfNotAssociatedWithHomesOrNeighborHoods(Guid homeId)
        {
            var homeAssociationsCount =
                this.Persistance.CreateQueryContext<UserHome>().Where(uh => uh.HomeId == homeId).Count();
            var neighborhoodAssociationsCount =
                this.Persistance.CreateQueryContext<NeighboorhoodHome>().Where(uh => uh.HomeId == homeId).Count();
            if (homeAssociationsCount + neighborhoodAssociationsCount == 0)
            {
                this.Persistance.Delete<Home>(homeId);
            }
        }
    }
}