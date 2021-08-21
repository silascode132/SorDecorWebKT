using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDecor.DATA.EF;

namespace WebDecor.Areas.Admin.Models
{
    public class ProductEditModel
    {
        public string productID { get; set; }
        public string productName { get; set; }
        public long made { get; set; }
        public long category { get; set; }
        public string productInfo { get; set; }
        public string productDes { get; set; }
        public decimal productPrice { get; set; }
        public decimal productSale { get; set; }
        public int productSL { get; set; }
        public IEnumerable<Made> mades { get; set; }
        public IEnumerable<Category> categories { get; set; }

    }
}