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
        public virtual ActionResult AddHome(string addressFull, double latitude, double longitude)
        {
            Contract.Requires(!String.IsNullOrEmpty(addressFull), "addressFull cannot be null");
            Contract.Requires(latitude >= -90 && latitude <= 90);
            Contract.Requires(longitude >= -180 && longitude <= 180);
            Contract.Assume(this.ModelState != null);
            this.VaildateAddHome(addressFull);

            if (this.ModelState.IsValid)
            {
                var nhid = this.GetNhId();

                Contract.Assume(latitude >= -90 && latitude <= 90);
                Contract.Assume(longitude >= -180 && longitude <= 180);
                var home = this.RepositoryFactory.Home.GetOrCreateHome(addressFull, latitude, longitude);
                this.RepositoryFactory.Home.SaveChanges();

                this.RepositoryFactory.Neighborhood.AddHome(nhid, home);
                this.RepositoryFactory.Neighborhood.SaveChanges();
                return this.RedirectToAction("Homes");
            }
            return this.View();
            
        }
        [Pure]
        private void VaildateAddHome(string addressFull)
        {
            Contract.Requires<ArgumentException>(!String.IsNullOrEmpty(addressFull));

            if (this.RepositoryFactory.Neighborhood.DoesHomeExist(this.GetNhId(), addressFull))
            {
                Contract.Assume(this.ModelState != null);
                this.ModelState.AddModelError("addressFull", "The home already exist in the neighborhood");
              //  this.ModelState.IsValid = false;
            }
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
