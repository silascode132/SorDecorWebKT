using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDecor.Areas.Admin.Models
{
    public class ProductModel
    {
        public string id { get; set; }
        public string productName { get; set; }
        public string made { get; set; }
        public string info { get; set; }
        public string des { get; set; }
        public decimal price { get; set; }
        public decimal sale { get; set; }
        public string category { get; set; }
        public bool freeship { get; set; }
        public string img { get; set; }
        public int sl { get; set; }
        public DateTime dateUpdate { get; set; }
        public bool stt { get; set; }
    }
}