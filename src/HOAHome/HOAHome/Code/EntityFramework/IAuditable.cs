using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOAHome.Code.EntityFramework
{
    public interface IAuditable : IEntity
    {
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }

    }
}