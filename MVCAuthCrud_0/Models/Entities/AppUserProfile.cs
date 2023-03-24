using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAuthCrud_0.Models.Entities
{
    public class AppUserProfile:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Relational Properties
        public virtual AppUser AppUser { get; set; }

    }
}