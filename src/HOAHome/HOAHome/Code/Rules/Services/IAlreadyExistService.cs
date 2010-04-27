using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOAHome.Code.Rules.Services
{
    public interface IAlreadyExistService
    {
        bool Exist(Guid notId, string fieldName, object value);
    }
}