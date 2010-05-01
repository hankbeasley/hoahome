using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;

namespace HOAHome.Code.Rules.Services
{
    [ContractClass(typeof(IAlreadyExistServiceContract))]
    public interface IAlreadyExistService
    {
        bool Exist(Guid notId, string fieldName, object value);
    }
    [ContractClassFor(typeof(IAlreadyExistService))]
    sealed class IAlreadyExistServiceContract : IAlreadyExistService
    {
        bool IAlreadyExistService.Exist(Guid notId, string fieldName, object value)
        {
            Contract.Requires(fieldName != null);
            Contract.Requires(value != null);
            return true;
        }
    }

   
}