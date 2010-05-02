using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOAHome.Repositories;

namespace HOAHome.Areas.nh.Controllers
{
    public abstract class NeighborhoodControllerBase : Controller
    {
        protected IRepositoryFactory RepositoryFactory { get; private set; }

        public NeighborhoodControllerBase(IRepositoryFactory repositoryFactory)
        {
            Contract.Requires(repositoryFactory != null);
            RepositoryFactory = repositoryFactory;
        }

        protected Guid GetNhId()
        {

            Contract.Ensures(Contract.Result<Guid>() != Guid.Empty);
            Contract.Assume(this.ControllerContext != null);
            Contract.Assume(this.ControllerContext.RouteData != null);
            Contract.Assume(this.ControllerContext.RouteData.Values != null);
            Contract.Assume(this.ControllerContext.RouteData.Values["nhid"] != null);

            string nhidText = (String)this.ControllerContext.RouteData.Values["nhid"];
            if (nhidText == null)
            {
                throw new ApplicationException("Could not get routing value nhid");
            }
            var nhid = new Guid(nhidText);
            if (nhid == Guid.Empty)
            {
                throw new ApplicationException("Invalid nhid");
            }
            Contract.Assume(nhid != Guid.Empty);
            return nhid;
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {

            Contract.Invariant(this.RepositoryFactory != null);
        }
    }
}