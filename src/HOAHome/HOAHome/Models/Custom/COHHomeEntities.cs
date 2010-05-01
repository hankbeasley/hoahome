using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using HOAHome.Code.EntityFramework;

namespace HOAHome.Models
{
    public partial class COHHomeEntities : IObjectContext
    {
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.MetadataWorkspace != null);

        }
    }
}