using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOAHome.Models
{
    public partial class Role
    {
        public static readonly Role Administrator = new Role { Id = new Guid("EC5FE847-90D9-4DE4-BF49-503EC4CEC8D5"), Name = "Administrator" };
        public static readonly Role Member = new Role { Id = new Guid("8487A6E8-2857-4320-9936-B14A25D22410"), Name = "Member" };

    }
}