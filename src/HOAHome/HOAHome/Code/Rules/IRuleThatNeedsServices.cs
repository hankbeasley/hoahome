using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOAHome.Code.Rules
{
    public interface IRuleThatNeedsServices : IRule
    {
        IEnumerable<Type> NeededServices { get; }
        bool IsValidUsingService(Dictionary<Type, object> serviceBundle);
    }
}