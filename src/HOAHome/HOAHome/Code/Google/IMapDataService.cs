using System.Collections.Generic;
using HOAHome.Models;
using HOAHome.Repositories;

namespace HOAHome.Code.Google
{
    public interface IMapDataService
    {
        void AddHome(Home home);
        IList<Point> GeoCodeAddress(string address);
        void Delete(string featureId);
        bool Exist(string featureId);
    }
}