using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HOAHome.Models;

namespace HOAHome.Services
{
    public interface IGisService
    {
        Neighborhood[] GetIntersectingNeighborhoods(double latitude, double longitude);
    }
}