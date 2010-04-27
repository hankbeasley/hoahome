using System;
using System.Collections.Generic;
using HOAHome.Models;


namespace HOAHome.Repositories
{
    public interface INeighborhoodRepository :IRepositoryBase<Neighborhood>
    {
        IList<Neighborhood> FindBySimilarName(string name);

        /// <summary>
        /// Find Nieghborhoods less that 5km from point
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        IList<Neighborhood> FindNearPoint(Point point);

        Neighborhood CreateNew(Neighborhood newNeighborhood, Guid userIdThatCreatedNeighborhood);
    }
}