using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOAHome.Repositories;

namespace HOAHome.Controllers
{
    [HandleError]
    public partial class HomeController : Controller
    {
        public HomeController(): this(new RepositoryFactory())
        {
        }

        public HomeController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        private IRepositoryFactory _repositoryFactory;
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult About()
        {
            return View();
        }

        public virtual ActionResult DisplaySearchResults(NeighborhoodRepository.SearchCriteria criteria)
        {
            return View(this._repositoryFactory.Neighborhood.Search(criteria));
        }


    }
}
