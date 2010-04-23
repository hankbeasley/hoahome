using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOAHome.Code.Mvc;

namespace HOAHome.Models
{
    [MetadataType(typeof(NeighborhoodMetaData))]
    [ModelBinder(typeof(CustomModelBinder))]
    public partial class Neighborhood
    {

    }

    public class NeighborhoodMetaData
    {
        [DisplayName("Name two")]
        [Required]
        public object Name { get; set; }
    }
}