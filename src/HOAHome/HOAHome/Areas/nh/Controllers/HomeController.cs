using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOAHome.Code.Mvc;
using HOAHome.Repositories;

namespace HOAHome.Areas.nh.Controllers
{
    public partial class HomeController : NeighborhoodControllerBase
    {
        public HomeController()
            : this(new RepositoryFactory())
        {
        }

        public HomeController(IRepositoryFactory repositoryFactory) : base(repositoryFactory)
        {
            Contract.Requires(repositoryFactory != null);
        }
        //
        // GET: /nh/Home/

        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ViewResult Homes()
        {
            var homes = this.RepositoryFactory.Neighborhood.GetHomes(this.GetNhId());
            return View(homes);
         
        }
        [NeighborhoodRole(NeighborhoodRoleName = "Administrator")]
        public virtual ViewResult AddHome()
        {
            return View();
        }

        
        [NeighborhoodRole(NeighborhoodRoleName = "Administrator")]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual RedirectToRouteResult AddHome(string addressFull, double latitude, double longitude)
        {
            Contract.Requires(addressFull != null, "addressFull cannot be null");
            Contract.Requires(latitude >= -90 && latitude <= 90);
            Contract.Requires(longitude >= -180 && longitude <= 180);

            var nhid = this.GetNhId();

            var home = this.RepositoryFactory.Home.GetOrCreateHome(addressFull, latitude, longitude);
            this.RepositoryFactory.Home.SaveChanges();

            this.RepositoryFactory.Neighborhood.AddHome(nhid, home);
            this.RepositoryFactory.Neighborhood.SaveChanges();

            return this.RedirectToAction("Homes");
        }
        [NeighborhoodRole(NeighborhoodRoleName = "Administrator")]
        public virtual RedirectToRouteResult RemoveHome(Guid homeId)
        {
            Contract.Requires(homeId != Guid.Empty);

            var nhid = this.GetNhId();
            this.RepositoryFactory.Neighborhood.RemoveHome(nhid, homeId);
            this.RepositoryFactory.Neighborhood.SaveChanges();

            this.RepositoryFactory.Home.DeleteIfNotAssociatedWithHomesOrNeighborHoods(homeId);
            this.RepositoryFactory.Home.SaveChanges();

            return this.RedirectToAction("Homes");
        }
    }
}
