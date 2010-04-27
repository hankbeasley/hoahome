using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOAHome.Code.Rules
{
    public interface IValidatableRegardingPersistence
    {
       // bool IsValidRegardingPersistence { get; }
        IList<IRule> BrokenRulesRegardingPersistence { get; }
        IList<IRule> PersistenceRelatedRules { get; }
    }
}