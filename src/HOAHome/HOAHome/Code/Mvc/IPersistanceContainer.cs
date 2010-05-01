using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using HOAHome.Models;

namespace HOAHome.Code.Mvc
{
    [ContractClass(typeof(IPersistanceContainerContract))]
    public interface IPersistanceContainer
    {
        object Load(Guid id);
    }
    [ContractClassFor(typeof(IPersistanceContainer))]
    sealed class IPersistanceContainerContract : IPersistanceContainer
    {
        public object Load(Guid id)
        {
            Contract.Requires(id != Guid.Empty);
            return null;
        }
    }
}