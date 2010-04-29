using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using HOAHome.Models;
using HOAHome.Repositories;

namespace HOAHome.Code.Security
{

    /// <summary>
    /// This has not been assigned in proper way to th context.User object
    /// </summary>
    public class Principal : IPrincipal
    {
        public IIdentity Identity
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

        public static bool IsUserInNeighborhoodRole(Guid userId, Guid neighborhoodId, Guid roleId)
        {
            return new AppUserRepository().IsUserInNeighborhoodRole(userId, neighborhoodId, roleId);
        }
    }
}