using MVCAuthCrud_0.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAuthCrud_0.Models.Entities
{
    public class AppUser:BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

        public AppUser()
        {
            Role = UserRole.Member;
        }

        //Relational Properties
        public virtual AppUserProfile Profile { get; set; }
        public virtual List<Order> Orders { get; set; }

    }
}