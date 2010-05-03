using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOAHome.Code.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HOAHome.Models
{
    [MetadataType(typeof(AppUserMetaData))]
    [ModelBinder(typeof(CustomModelBinder))]
    public partial class AppUser
    {
        public String ToCookieString()
        {
            //return string.Format(
            //    "{0}|{1}",
            //    this.FirstName,
            //    this.LastName);
            return this.DisplayName;
        }

        public static AppUser FromCookieString(Guid id, string userData){
            Contract.Ensures(Contract.Result<AppUser>() != null);
            //string[] items = userData.Split('|');
            //return new AppUser { Id = id, FirstName = items[0], LastName = items[1] };
            return new AppUser { Id = id, DisplayName = userData };
        }
    }


    public class AppUserMetaData
    {
        //[DisplayName("First Name")]
        [Required]
        public object FirstName { get; set; }

       // [DisplayName("Last Name")]
        [Required]
        public object LastName { get; set; }

        //[DisplayName("Display Namey")]
        //[Display(AutoGenerateFilter = )]
        [Required]
        public object DisplayName { get; set; }

    }
    
}