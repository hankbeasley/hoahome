using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using HOAHome.Code.Rules.Services;
using HOAHome.Models;


namespace HOAHome.Repositories
{
    [ContractClass(typeof(INeighborhoodRepositoryContract))]
    public interface INeighborhoodRepository : IRepositoryBase<Neighborhood>, IAlreadyExistService
    {
        IList<Neighborhood> FindBySimilarName(string name);

        /// <summary>
        /// Find Nieghborhoods less that 5km from point
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        IList<Neighborhood> FindNearPoint(Point point);

        Neighborhood CreateNew(Neighborhood newNeighborhood, Guid userIdThatCreatedNeighborhood);
        IList<Home> GetHomes(Guid neighborhoodId);

        void RemoveHome(Guid neighborhoodId, Guid homeId);

        NeighborhoodHome AddHome(Guid neighborhoodId, Home home);


        bool DoesHomeExist(Guid neighborhoodId, string addressFull);

    }

    [ContractClassFor(typeof(INeighborhoodRepository))]
    sealed class INeighborhoodRepositoryContract : INeighborhoodRepository
    {
        Neighborhood IRepositoryBase<Neighborhood>.Get(Guid id)
        {
            throw new NotImplementedException();
        }

        IList<Neighborhood> IRepositoryBase<Neighborhood>.GetAll()
        {
            throw new NotImplementedException();
        }

        void IRepositoryBase<Neighborhood>.Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        void IRepositoryBase<Neighborhood>.SaveChanges()
        {
            throw new NotImplementedException();
        }

        bool IAlreadyExistService.Exist(Guid notId, string fieldName, object value)
        {
            throw new NotImplementedException();
        }

        IList<Neighborhood> INeighborhoodRepository.FindBySimilarName(string name)
        {
            Contract.Ensures(Contract.Result<IList<Neighborhood>>() != null);
            return null;
        }

        IList<Neighborhood> INeighborhoodRepository.FindNearPoint(Point point)
        {
            Contract.Ensures(Contract.Result<IList<Neighborhood>>() != null);
            return null;
        }

        Neighborhood INeighborhoodRepository.CreateNew(Neighborhood newNeighborhood, Guid userIdThatCreatedNeighborhood)
        {
            Contract.Requires<ArgumentNullException>(newNeighborhood != null);
            return null;
        }

        IList<Home> INeighborhoodRepository.GetHomes(Guid neighborhoodId)
        {
            throw new NotImplementedException();
        }


        void INeighborhoodRepository.RemoveHome(Guid neighborhoodId, Guid homeId)
        {
            throw new NotImplementedException();
        }


        NeighborhoodHome INeighborhoodRepository.AddHome(Guid neighborhoodId, Home home)
        {
            Contract.Requires(neighborhoodId != Guid.Empty);
            Contract.Requires(home != null);
            //Contract.Requires(home.Id != Guid.Empty);
            Contract.Ensures(Contract.Result<NeighborhoodHome>() != null);
            return null;
        }

        [Pure]
        bool INeighborhoodRepository.DoesHomeExist(Guid neighborhoodId, string addressFull)
        {
            Contract.Requires<ArgumentException>(!String.IsNullOrEmpty(addressFull));
            return false;
        }
    }
}