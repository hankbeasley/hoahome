using System;
using System.Diagnostics.Contracts;
using HOAHome.Code.ContentManagement;

namespace HOAHome.Repositories
{
    [ContractClass(typeof(IRepositoryFactoryContract))]
    public interface IRepositoryFactory
    {
        INeighborhoodRepository Neighborhood { get; }
        IHomeRepository Home { get;  }
        IContentRepository ContentRepository(Guid nhid);
    }
    [ContractClassFor(typeof(IRepositoryFactory))]
    sealed class IRepositoryFactoryContract : IRepositoryFactory
    {
        INeighborhoodRepository IRepositoryFactory.Neighborhood
        {
            get { Contract.Ensures(Contract.Result<INeighborhoodRepository>() != null);
                return null;}
        }

        IHomeRepository IRepositoryFactory.Home
        {
            get { Contract.Ensures(Contract.Result<IHomeRepository>() != null);
                return null;
            }
        }


        public IContentRepository ContentRepository(Guid nhid)
        {

            Contract.Ensures(Contract.Result<IContentRepository>() != null);
            return null;
        }
    }
}