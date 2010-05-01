using System;
using System.Diagnostics.Contracts;

namespace HOAHome.Repositories
{
    [ContractClass(typeof(IRepositoryFactoryContract))]
    public interface IRepositoryFactory
    {
        INeighborhoodRepository Neighborhood { get; }
        IHomeRepository Home { get;  }
    }
    [ContractClassFor(typeof(IRepositoryFactory))]
    sealed class IRepositoryFactoryContract : IRepositoryFactory
    {
        INeighborhoodRepository IRepositoryFactory.Neighborhood
        {
            get { throw new NotImplementedException(); }
        }

        IHomeRepository IRepositoryFactory.Home
        {
            get { throw new NotImplementedException(); }
        }
    }
}