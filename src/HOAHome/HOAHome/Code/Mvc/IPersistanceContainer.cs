using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HOAHome.Models;

namespace HOAHome.Code.Mvc
{
    public interface IPersistanceContainer
    {
        object Load(Guid id);
    }
}