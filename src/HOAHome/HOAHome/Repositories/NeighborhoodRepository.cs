using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HOAHome.Code.EntityFramework;
using HOAHome.Models;

namespace HOAHome.Repositories
{
    public class NeighborhoodRepository : INeighborhoodRepository
    {
        private IPersistanceFramework _persistance;

        public NeighborhoodRepository(IPersistanceFramework persistance)
        {
            _persistance = persistance;
        }

        //public IList<Neighborhood> Search(SearchCriteria criteria)
        //{
        //    var results = new List<Neighborhood>();
        //    if (!string.IsNullOrEmpty(criteria.Name))
        //    {
        //        results.AddRange(this._persistance.CreateQueryContext<Neighborhood>().Where(n => n.Name.Contains(criteria.Name)));
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
            results.AddRange(this._persistance.CreateQueryContext<Neighborhood>().Where(n => n.Name.Contains(name)));
            return results.AsReadOnly();
        }
        /// <summary>
        /// Find Nieghborhoods less that 5km from point
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public IList<Neighborhood> FindNearPoint(Point point)
        {
            var results = new List<Neighborhood>();
            results.AddRange(this._persistance.ExecuteStoreQuery<Neighborhood>(
                string.Format(
                "SELECT * FROM Neighborhood WHERE geography::STGeomFromText('POINT({0} {1})', 4326).STDistance(Geo) < 5000",
                point.Longitude, point.Latitude)));
            return results.AsReadOnly();
        }


    }
}