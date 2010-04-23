using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOAHome.Code.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HOAHome.Models
{
    [MetadataType(typeof(UserHomeMetaData))]
    [ModelBinder(typeof(CustomModelBinder))]
    public partial class UserHome
    {
        public UserHome()
        {
            
        }
    }


    public class UserHomeMetaData
    {
        [DisplayName("Name")]
        [Required]
        public object Name{get;set;}
    }
}