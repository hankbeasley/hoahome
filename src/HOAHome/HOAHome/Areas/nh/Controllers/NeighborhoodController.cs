using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOAHome.Code.ContentManagement;
using HOAHome.Code.EntityFramework;
using HOAHome.Models;
using HOAHome.Repositories;

namespace HOAHome.Areas.nh.Controllers
{
    public partial class NeighborhoodController : NeighborhoodControllerBase
    {
        public NeighborhoodController():base(new RepositoryFactory()){}
        
        
        
        public virtual ViewResult Index()
        {
            Contract.Assume(this.ViewData != null);
            this.ViewData.Add("id", this.GetNhId().ToString());
            var bundle = new ContentBundle();
            bundle.Add(ContentType.HomePageMain.Id, this.RepositoryFactory.ContentRepository(this.GetNhId()).GetContent(ContentType.HomePageMain));
            Contract.Assume(this.ViewData != null);
            this.ViewData.Add(typeof(ContentBundle).Name, bundle);
            return View();
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {


        }
    }
}
