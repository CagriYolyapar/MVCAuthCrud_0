using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAuthCrud_0.Models.PureVms
{
    public class ProductUpdateRequestModel
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? CategoryID { get; set; }

    }
}