using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HOAHome.Code.EntityFramework;

namespace HOAHome.Code.Rules
{
    public interface IEntityWithRules<T>:IEntity
    {
        RuleSet<T> Rules { get; }
    }
}