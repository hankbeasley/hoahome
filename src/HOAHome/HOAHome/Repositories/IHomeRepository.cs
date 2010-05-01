using System;
using System.Diagnostics.Contracts;
using HOAHome.Models;

namespace HOAHome.Repositories
{
    [ContractClass(typeof(IHomeRepositoryContract))]
    public interface IHomeRepository : IRepositoryBase<Home>
    {
        Home GetOrCreateHome(string addressFull, double latitude, double longitude);

        void DeleteIfNotAssociatedWithHomesOrNeighborHoods(System.Guid homeId);
    }

    [ContractClassFor(typeof(IHomeRepository))]
    sealed class IHomeRepositoryContract : IHomeRepository
    {
        Home IHomeRepository.GetOrCreateHome(string addressFull, double latitude, double longitude)
        {
           Contract.Requires(addressFull != null);
           Contract.Requires(latitude >=-90 && latitude <= 90);
           Contract.Requires(longitude >= -180 && longitude <= 180);

            Contract.Ensures(Contract.Result<Home>() != null);
            
            return null;
        }

        void IHomeRepository.DeleteIfNotAssociatedWithHomesOrNeighborHoods(System.Guid homeId)
        {
            Contract.Requires(homeId != Guid.Empty);
        }

        Home IRepositoryBase<Home>.Get(System.Guid id)
        {
            throw new System.NotImplementedException();
        }

        System.Collections.Generic.IList<Home> IRepositoryBase<Home>.GetAll()
        {
            throw new System.NotImplementedException();
        }

        void IRepositoryBase<Home>.Delete(System.Guid id)
        {
            throw new System.NotImplementedException();
        }

        void IRepositoryBase<Home>.SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}