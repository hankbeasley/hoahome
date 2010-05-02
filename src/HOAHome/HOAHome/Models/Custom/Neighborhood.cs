using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOAHome.Code.Mvc;
using HOAHome.Code.Rules;

namespace HOAHome.Models
{
    [MetadataType(typeof(NeighborhoodMetaData))]
    [ModelBinder(typeof(CustomModelBinder))]
    public partial class Neighborhood : IEntityWithRules<Neighborhood> {

        public Neighborhood()
        {
            this.Rules = new RuleSet<Neighborhood>(this, new UniqueFieldRule<Neighborhood, string>("Name", this, (n =>n.Name))
                );
        }

        public RuleSet<Neighborhood> Rules { get; private set; }

    }

    public class NeighborhoodMetaData
    {
        [DisplayName("Name")]
        [Required]
        public object Name { get; set; }
    }
}