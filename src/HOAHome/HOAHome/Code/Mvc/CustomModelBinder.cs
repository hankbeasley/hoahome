using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HOAHome.Code.Mvc
{
    public class CustomModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            var idValue = bindingContext.ValueProvider.GetValue("Id");
          
            if (!string.IsNullOrEmpty(idValue.AttemptedValue))
            {
                Guid id = new Guid(idValue.AttemptedValue);
                Contract.Assume(id != Guid.Empty);
                var entity = ((IPersistanceContainer)controllerContext.Controller).Load(id);
                return entity;
            }
            else
            {
                return base.CreateModel(controllerContext, bindingContext, modelType);
            }
        }
    }
}