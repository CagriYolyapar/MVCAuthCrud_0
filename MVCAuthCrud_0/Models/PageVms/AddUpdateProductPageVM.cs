using MVCAuthCrud_0.Models.PureVms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAuthCrud_0.Models.PageVms
{
    public class AddUpdateProductPageVM
    {
        public ProductVM Product { get; set; }
        public List<CategoryVM> Categories { get; set; }

    }
}