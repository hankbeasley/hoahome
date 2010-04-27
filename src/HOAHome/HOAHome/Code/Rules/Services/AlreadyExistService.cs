using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOAHome.Code.Rules.Services
{
    public class AlreadyExistService : IAlreadyExistService
    {
        private Func<Guid, string, object, bool> _existFunction;

        public AlreadyExistService(Func<Guid, string, object, bool> existFunction)
        {
            _existFunction = existFunction;
        }

        public bool Exist(Guid notId, string fieldName, object value)
        {
            return _existFunction(notId, fieldName, value);
        }
    }
}