using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAuthCrud_0.Models.PureVms
{
    //Add icin (Eklemek icin)
    public class ProductCreateRequestModel
    {
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? CategoryID { get; set; }

    }
}