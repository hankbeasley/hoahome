using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOAHome.Code.EntityFramework
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}