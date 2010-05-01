using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using HOAHome.Models;
using System.ServiceModel;

namespace HOAHome.Services
{
    //[ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class HoaService : IHoaService
    {
        public Neighborhood[] GetNeighborhoods(string latitude, string longitude)
        {
           
            return  new GisService().GetIntersectingNeighborhoods(double.Parse(latitude), double.Parse(longitude));
        }

       
    }
}