﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HOAHome.Controllers
{
    [HandleError]
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult About()
        {
            return View();
        }

        public virtual ActionResult DisplaySearchResults()
        {
            return View();
        }
    }
}
