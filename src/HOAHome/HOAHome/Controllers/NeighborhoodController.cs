using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Google.GData.Calendar;
using DotNetOpenAuth.OAuth.Messages;
using DotNetOpenAuth.OAuth;
using DotNetOpenAuth.Messaging;
using HOAHome.Code;
using Google.GData.Client;
using DotNetOpenAuth.ApplicationBlock;
using Google.GData.Contacts;
using Google.Contacts;
using HOAHome.Code.ContentManagement;
using HOAHome.Code.EntityFramework;
using HOAHome.Code.Mvc;
using HOAHome.Code.Rules.Services;
using HOAHome.Models;
using GeoCoding.Services;
using GeoCoding.Services.Google;
using HOAHome.Repositories;

namespace HOAHome.Controllers
{
    public partial class NeighborhoodController : RepositoryController<INeighborhoodRepository, Neighborhood>
    {
        public NeighborhoodController()
            : this(new NeighborhoodRepository(new PersistanceFramework(new COHHomeEntities())))
        {
        }
        public NeighborhoodController(INeighborhoodRepository repository)
            : base(repository)
        {
            
        }
        private ContentRepository ContentRepository
        {
            get
            {
                if (this._contentRepository == null)
                {
                    this._contentRepository =
                   new ContentRepository(new Guid(this.ControllerContext.RouteData.Values["nhid"].ToString()),
                                         new PersistanceFramework(new COHHomeEntities()));
                }
                return this._contentRepository;
            }
        }

        private ContentRepository _contentRepository;

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult Create([Bind(Exclude = "Id")]Neighborhood entity)
        {
            this.Repository.CreateNew(entity, HOAHome.Code.Security.Identity.Current.Id);
            entity.Rules.AddErrorsToModelState(this.ModelState, this.Repository);
            if (this.ModelState.IsValid)
            {
                this.Repository.SaveChanges();
                return this.RedirectToAction("Details", new {entity.Id});
            } else
            {
                return this.View("Create");
            }
        }

        //protected override void Validate(CustomController<Neighborhood>.ActionType actionType, Neighborhood entity)
        //{
        //    var existingCount = this.Persistance.CreateQueryContext<Neighborhood>().Where(n => n.Name == entity.Name).Count();
        //    if (existingCount > 0)
        //    {
        //        this.ModelState.AddModelError("Name", string.Format("The neighborhood name, {0}, is already in the system. Please pick another one", entity.Name));
        //    }
        //    base.Validate(actionType, entity);
        //}

        //protected override ActionResult GetInitialResult(CustomController<Neighborhood>.ActionType type, Neighborhood entity)
        //{
        //    if (type == ActionType.Edit) {
        //        return this.View("Create");
        //    }
        //    return base.GetInitialResult(type, entity);
        //}

        //public virtual ViewResult Locate(string searchString)
        //{

        //    //TODO: I don't think this is used yet?
        //    IGeoCoder geoCoder = new GoogleGeoCoder(Configuration.GoogleApiKey);
        //    return View();
        //}

        public virtual ViewResult Index()
        {
            //this.ControllerContext.RouteData.
            this.ViewData.Add("id", this.ControllerContext.RouteData.Values["nhid"]);
            var bundle = new ContentBundle();
            bundle.Add(ContentType.HomePageMain.Id, this.ContentRepository.GetContent(ContentType.HomePageMain));
            this.ViewData.Add(typeof(ContentBundle).Name, bundle);
            return View();
        }

    }
}
