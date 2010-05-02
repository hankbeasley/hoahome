using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HOAHome.Code.Mvc
{
    public class ModelMetadataProvider : System.Web.Mvc.AssociatedMetadataProvider
    {

        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
