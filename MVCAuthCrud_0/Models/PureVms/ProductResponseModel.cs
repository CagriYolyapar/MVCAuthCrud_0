using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAuthCrud_0.Models.PureVms
{

    //Kompleks mimarilerde VM, kullanıcıya gösterilecek yapı ve kullanıcıdan alınacak yapı diye ikiye ayrılır...Altta gördügünüz sınıf bu sistemde kullanıcıya gösterilecek yapıdır(Yani ResponseModel)
    public class ProductResponseModel
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public string CategoryName { get; set; }

    }
}