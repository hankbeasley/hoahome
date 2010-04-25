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

        public IList<Neighborhood> Search(SearchCriteria criteria)
        {
            var results = new List<Neighborhood>();
            if (!string.IsNullOrEmpty(criteria.Name))
            {
                results.AddRange(this._persistance.CreateQueryContext<Neighborhood>().Where(n => n.Name.Contains(criteria.Name)));
            }

            if (!string.IsNullOrEmpty(criteria.Address))
            {
                throw new NotImplementedException("Have not complete this type of search yet");
            }

            return results.AsReadOnly();
        }
        public class SearchCriteria
        {
            /// <summary>
            /// Searchs for a Neighborhood where the name Like '%name%'
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Searches within two miles of this address entered
            /// </summary>
            public string Address { get; set; }
        }
    }
}