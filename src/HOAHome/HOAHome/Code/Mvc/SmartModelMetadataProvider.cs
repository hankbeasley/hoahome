﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HOAHome.Code.Mvc
{
    public class SmartModelMetadataProvider : Microsoft.Web.Mvc.AspNet4.DataAnnotations4ModelMetadataProvider
    {
        
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            var metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
            
            Contract.Assume(metadata != null);
            Contract.Assume(attributes != null);

            DisplayAttribute display = attributes.OfType<DisplayAttribute>().FirstOrDefault();
            if (display != null)
            {
                if (!display.AutoGenerateField)
                {
                    metadata.ShowForDisplay = false;
                }
            }
            
            if (propertyName == null) return metadata;
            if (propertyName.EndsWith("Id"))
            {
                metadata.TemplateHint = "HiddenInput";
                metadata.HideSurroundingHtml = true;
                metadata.ShowForDisplay = false;
            }

            if (propertyName == "CreatedBy" || propertyName == "ModifiedBy" || propertyName == "CreatedDate" || propertyName == "ModifiedDate")
            {
               metadata.ShowForDisplay = false;
               metadata.ShowForEdit = false;
            }

            if (string.IsNullOrEmpty(metadata.DisplayName))
            {
                metadata.DisplayName = Wordify(propertyName);
            }
            return metadata;

        }

        
        private static string Wordify(string str)
        {
            Contract.Requires<ArgumentNullException>(str != null, "str");
            string newString = "";
            string space = "";
            foreach (char c in str)
            {
                newString += char.IsUpper(c) ? space + c : c.ToString();
                space = " ";
            }
            return newString;
        }


    }
}
