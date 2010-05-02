using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using HOAHome.Code.EntityFramework;
using HOAHome.Models;

namespace HOAHome.Repositories
{
    public class AppUserRepository : RepositoryBase<AppUser>
    {
        public AppUserRepository() : this(new PersistanceFramework(new COHHomeEntities()))
        {
        }

        public AppUserRepository(IPersistanceFramework persistance) : base(persistance)
        {
            Contract.Requires<ArgumentNullException>(persistance != null);
        }

        public bool IsUserInNeighborhoodRole(Guid userId, Guid neighborhoodId, Guid roleId)
        {
            return
                this.Persistance.CreateQueryContext<UserNeighborhood>().Any(
                    u => u.NeighborhoodId == neighborhoodId && u.RoleId == roleId && userId == u.UserId);
        }

    }
}