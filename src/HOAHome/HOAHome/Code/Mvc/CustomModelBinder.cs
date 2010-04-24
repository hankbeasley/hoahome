using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HOAHome.Code.Mvc
{
    public class CustomModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            
            
            if (!string.IsNullOrEmpty(bindingContext.ValueProvider.GetValue("Id").AttemptedValue))
            {
                Guid id = new Guid(bindingContext.ValueProvider.GetValue("Id").AttemptedValue);
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