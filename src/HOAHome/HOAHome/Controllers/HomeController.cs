using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOAHome.Code.Google;
using HOAHome.Models;
using HOAHome.Repositories;

namespace HOAHome.Controllers
{
    [HandleError]
    public partial class HomeController : Controller
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IMapDataService _mapService;

        public HomeController(): this(new RepositoryFactory(), new MapDataService())
        {
        }

        public HomeController(IRepositoryFactory repositoryFactory, IMapDataService mapService)
        {
            Contract.Requires(repositoryFactory != null);
            Contract.Requires(mapService != null);
            _repositoryFactory = repositoryFactory;
            _mapService = mapService;
        }



        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult About()
        {
            return View();
        }
        [HttpPost]
        public virtual ActionResult DisplaySearchResults(string search)
        {
            //if (!string.IsNullOrWhiteSpace(criteria.Name) && !string.IsNullOrWhiteSpace(criteria.Address))
            //{
            //    throw new InvalidOperationException("Can not search by address and name at the same time");
            //}

            var results = new List<Neighborhood>();
            //if (!string.IsNullOrEmpty(criteria.Name))
            //{
                results.AddRange(this._repositoryFactory.Neighborhood.FindBySimilarName(search));
            //}

            //if (!string.IsNullOrEmpty(criteria.Address))
            //{
                var points = this._mapService.GeoCodeAddress(search);
                foreach(Point point in points)
                {
                    results.AddRange(this._repositoryFactory.Neighborhood.FindNearPoint(point));
                }
           // }
            return View(results.AsReadOnly());
        }

        [ContractInvariantMethod]
        void ObjectInvariant()
        {
            Contract.Invariant(this._mapService != null);
            Contract.Invariant(this._repositoryFactory != null);
        }


    }
}
