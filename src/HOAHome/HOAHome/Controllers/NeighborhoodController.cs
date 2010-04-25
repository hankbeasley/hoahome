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
using HOAHome.Code.Mvc;
using HOAHome.Models;
using GeoCoding.Services;
using GeoCoding.Services.Google;

namespace HOAHome.Controllers
{
    public partial class NeighborhoodController : CustomController<Neighborhood>
    {
        public override ActionResult Create(Neighborhood entity)
        {
            entity.PrimaryContactId = HOAHome.Code.Security.Identity.Current.Id;
            return base.Create(entity);
        }

        protected override void Validate(CustomController<Neighborhood>.ActionType actionType, Neighborhood entity)
        {
            var existingCount = this.Persistance.CreateQueryContext<Neighborhood>().Where(n => n.Name == entity.Name).Count();
            if (existingCount > 0)
            {
                this.ModelState.AddModelError("Name", string.Format("The neighborhood name, {0}, is already in the system. Please pick another one", entity.Name));
            }
            base.Validate(actionType, entity);
        }

        protected override ActionResult GetInitialResult(CustomController<Neighborhood>.ActionType type, Neighborhood entity)
        {
            if (type == ActionType.Edit) {
                return this.View("Create");
            }
            return base.GetInitialResult(type, entity);
        }

        public virtual ViewResult Locate(string searchString)
        {

            //TODO: I don't think this is used yet?
            IGeoCoder geoCoder = new GoogleGeoCoder(Configuration.GoogleApiKey);
            return View();
        }
    }
}
