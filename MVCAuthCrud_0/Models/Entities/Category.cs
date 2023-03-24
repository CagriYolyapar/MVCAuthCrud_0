using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAuthCrud_0.Models.Entities
{
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }

        //Relational Properties
        public virtual List<Product> Products { get; set; }
    }
}