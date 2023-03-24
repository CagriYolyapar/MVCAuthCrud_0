using MVCAuthCrud_0.Models.Context;
using MVCAuthCrud_0.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCAuthCrud_0.Models.Init
{
    public class MyInit:CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            AppUser ap = new AppUser
            {
                UserName = "cgr",
                Password = "cgr123",
                Role = Enums.UserRole.Admin
               
            };

            context.AppUsers.Add(ap);
            context.SaveChanges();
        }
    }
}