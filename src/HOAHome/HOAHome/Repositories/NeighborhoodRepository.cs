using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using HOAHome.Code.EntityFramework;
using HOAHome.Code.Rules.Services;
using HOAHome.Models;

namespace HOAHome.Repositories
{
    public class NeighborhoodRepository : RepositoryBase<Neighborhood>, INeighborhoodRepository
    {
        public NeighborhoodRepository(IPersistanceFramework persistance) : base(persistance)
        {
            Contract.Requires<ArgumentNullException>(persistance != null);
        }

        public Neighborhood CreateNew(Neighborhood newNeighborhood, Guid userIdThatCreatedNeighborhood)
        {
            
            if (newNeighborhood.PrimaryContactId == Guid.Empty)
            {
                newNeighborhood.PrimaryContactId = userIdThatCreatedNeighborhood;
            }
            this.Persistance.AttachNew(newNeighborhood);
            var userNeighborhood = new UserNeighborhood();
            userNeighborhood.Neighborhood = newNeighborhood;
            userNeighborhood.UserId = userIdThatCreatedNeighborhood;
            userNeighborhood.RoleId = Role.Administrator.Id;
            this.Persistance.AttachNew(userNeighborhood);
            return newNeighborhood;
        }

       public bool DoesAnotherNeighborhoodWithNameExist(Guid notId, string name)
       {
           return this.Persistance.CreateQueryContext<Neighborhood>().Where(n => n.Id != notId && n.Name == name).Count()>0;
       }

       public IList<Home> GetHomes(Guid neighborhoodId)
       {
           return this.Persistance.CreateQueryContext<Home>().Where(
               h => h.NeighborhoodHomes.Any(n => n.NeighborhoodId == neighborhoodId)).ToList();
       }
        //public IList<Neighborhood> Search(SearchCriteria criteria)
        //{
        //    var results = new List<Neighborhood>();
        //    if (!string.IsNullOrEmpty(criteria.Name))
        //    {
        //        results.AddRange(this.Persistance.CreateQueryContext<Neighborhood>().Where(n => n.Name.Contains(criteria.Name)));
        //    }

        //    if (!string.IsNullOrEmpty(criteria.Address))
        //    {
        //        var stuff = new COHHomeEntities().ExecuteStoreQuery<Neighborhood>("select * from");
        //        //stuff.
        //        throw new NotImplementedException("Have not complete this type of search yet");
        //    }

        //    return results.AsReadOnly();
        //}

        public IList<Neighborhood> FindBySimilarName(string name)
        {
            var results = new List<Neighborhood>();
            results.AddRange(this.Persistance.CreateQueryContext<Neighborhood>().Where(n => n.Name.Contains(name)));
            return results.AsReadOnly();
        }
        /// <summary>
        /// Find Neighborhoods less that 5km from point
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public IList<Neighborhood> FindNearPoint(Point point)
        {
            var results = new List<Neighborhood>();
            results.AddRange(this.Persistance.ExecuteStoreQuery<Neighborhood>(
                string.Format(
                "SELECT * FROM Neighborhood WHERE geography::STGeomFromText('POINT({0} {1})', 4326).STDistance(Geo) < 5000",
                point.Longitude, point.Latitude)));
            return results.AsReadOnly();
        }



        bool IAlreadyExistService.Exist(Guid notId, string fieldName, object value)
        {
            if (fieldName == "Name")
            {
                return this.DoesAnotherNeighborhoodWithNameExist(notId, value.ToString());
            }
            throw new InvalidOperationException("Don't know how to find unique on other columns");
        }


        public void RemoveHome(Guid neighborhoodId, Guid homeId)
        {
            var neighborhoodHome = this.Persistance.CreateQueryContext<NeighborhoodHome>().Where(nh => nh.NeighborhoodId == neighborhoodId && homeId == nh.HomeId).Single();
            Contract.Assume(neighborhoodHome != null);
            this.Persistance.Delete(neighborhoodHome);
        }
        public bool DoesHomeExist(Guid neighborhoodId, string address)
        {
         

            return
                this.Persistance.CreateQueryContext<NeighborhoodHome>().Where(
                    nh => nh.NeighborhoodId == neighborhoodId && nh.Home.AddressFull == address).Count() > 0;
        }

        public NeighborhoodHome AddHome(Guid neighborhoodId, Home home)
        {
            var neighborhoodHome = this.Persistance.Create<NeighborhoodHome>();
            neighborhoodHome.NeighborhoodId = neighborhoodId;
            neighborhoodHome.HomeId = home.Id;
            return neighborhoodHome;
        }
    }
}