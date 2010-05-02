using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using HOAHome.Models;
using HOAHome.Repositories;

namespace HOAHome.Code.Google
{
    [ContractClass(typeof(IMapDataServiceContract))]
    public interface IMapDataService
    {
        void AddHome(Home home);
        IList<Point> GeoCodeAddress(string address);
        void Delete(string featureId);
        bool Exist(string featureId);
    }
    

    [ContractClassFor(typeof(IMapDataService))]
    public sealed class IMapDataServiceContract : IMapDataService
    {
        public void AddHome(Home home)
        {
            throw new NotImplementedException();
        }

        public IList<Point> GeoCodeAddress(string address)
        {
            Contract.Ensures(Contract.Result<IList<Point>>() != null);
            return null;
        }

        public void Delete(string featureId)
        {
            throw new NotImplementedException();
        }

        public bool Exist(string featureId)
        {
            throw new NotImplementedException();
        }
    }
  

}