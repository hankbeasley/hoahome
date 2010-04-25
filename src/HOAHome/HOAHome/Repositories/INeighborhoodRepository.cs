using System.Collections.Generic;
using HOAHome.Models;

namespace HOAHome.Repositories
{
    public interface INeighborhoodRepository
    {
        IList<Neighborhood> Search(NeighborhoodRepository.SearchCriteria criteria);
    }
}