using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;

namespace HOAHome.Repositories
{
    public struct Point
    {
        public double Latitude;
        public double Longitude;

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {

            Contract.Invariant(Latitude >= -90 && Latitude <= 90);
            Contract.Invariant(Longitude >= -180 && Longitude <= 180);
           
        }
    }
}