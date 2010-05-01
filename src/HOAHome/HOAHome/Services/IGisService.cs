using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using HOAHome.Models;

namespace HOAHome.Services
{
    [ContractClass(typeof(IGisServiceContract))]
    public interface IGisService
    {
        Neighborhood[] GetIntersectingNeighborhoods(double latitude, double longitude);
    }

    [ContractClassFor(typeof(IGisService))]
    sealed class IGisServiceContract : IGisService
    {
        Neighborhood[] IGisService.GetIntersectingNeighborhoods(double latitude, double longitude)
        {
            Contract.Ensures(Contract.Result<Neighborhood[]>()!= null);
            return null;
        }
    }
}