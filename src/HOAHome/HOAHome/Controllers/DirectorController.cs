using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace HOAHome.Controllers
{
    public partial class DirectorController : Controller
    {
        //
        // GET: /Director/

        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Financals()
        {
            return View();
        }

        public virtual ActionResult Members()
        {
            return View();
        }

    }
}
