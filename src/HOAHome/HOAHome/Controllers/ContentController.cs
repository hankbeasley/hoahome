using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOAHome.Code.ContentManagement;
using HOAHome.Code.EntityFramework;
using HOAHome.Models;

namespace HOAHome.Controllers
{
    public partial class ContentController : Controller
    {
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
        [ValidateInput(false)]
        public virtual ActionResult Update(Guid id, string content)
        {
            this.ContentRepository.SetContent(id, content);
            this.ContentRepository.SaveChanges();
            return this.Json("Nothing");
        }

    }
}
