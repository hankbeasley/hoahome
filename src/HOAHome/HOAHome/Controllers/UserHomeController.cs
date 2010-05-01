using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using HOAHome.Models;
using HOAHome.Code.Mvc;
using HOAHome.Code.Google;

namespace HOAHome.Controllers
{
    public partial class UserHomeController : CustomController<UserHome>
    {
        protected override void AssociateParent(Guid parentId, UserHome entity)
        {
           entity.AppUserId = parentId;
        }
        protected override ActionResult GetCompletionResult(ActionType type, UserHome entity)
        {
           return this.RedirectToAction(MVC.Account.Settings());
        }
        public virtual ActionResult CreateChildByAddress(Guid parentId)
        {
            return base.CreateChild(parentId);
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult CreateChildByAddress(Guid parentId, [Bind(Exclude = "Id")] UserHome userHome, string addressFull, double latitude, double longitude)
        {
            Contract.Requires(addressFull != null, "addressFull cannot be null");
            Contract.Requires(userHome.Name != null);
            //Contract.Requires(latitude != 0);
            //Contract.Requires(longitude != 0);

            var home = this.Persistance.CreateQueryContext<Home>().Where(h => h.AddressFull == addressFull).FirstOrDefault();
            if (home == null)
            {
                home = this.Persistance.Create<Home>();
                home.AddressFull = addressFull;
                home.Latitude = latitude;
                home.Longitude = longitude;
                //var mapService = new MapDataService();
                //mapService.AddHome(home);
                userHome.Home = home;
                try
                {
                   return base.CreateChild(parentId, userHome);
                }
                catch (Exception ex)
                {
                    //try
                    //{
                    //    mapService.Delete(home.GoogleFeatureId);
                    //}
                    //catch { }
                    try
                    {
                        this.Persistance.Delete<Home>(home.Id);
                    }
                    catch { }
                    throw new ApplicationException("Error saving new home, rolling back transaction", ex);
                }
            }
            else
            {
                userHome.Home = home;
               return base.CreateChild(parentId, userHome);
            }
        }

 
    }
}
