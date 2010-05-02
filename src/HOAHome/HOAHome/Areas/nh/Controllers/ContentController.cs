using System;
using System.Diagnostics.Contracts;
using System.Web.Mvc;
using HOAHome.Code.ContentManagement;
using HOAHome.Code.EntityFramework;
using HOAHome.Code.Mvc;
using HOAHome.Models;
using HOAHome.Repositories;

namespace HOAHome.Areas.nh.Controllers
{
    public partial class ContentController : NeighborhoodControllerBase
    {
        public ContentController() : this(new RepositoryFactory())
        {
        }

        public ContentController(IRepositoryFactory repositoryFactory) : base(repositoryFactory)
        {
            Contract.Requires<ArgumentNullException>(repositoryFactory != null, "repositoryFactory");
        }

       

      
        [NeighborhoodRole(NeighborhoodRoleName = "Administrator")]
        [ValidateInput(false)]
        public virtual ActionResult Update(Guid id, string content)
        {
            this.RepositoryFactory.ContentRepository(this.GetNhId()).SetContent(id, content);
            this.RepositoryFactory.ContentRepository(this.GetNhId()).SaveChanges();
            
            return this.Json("Nothing");
        }

    }
}
