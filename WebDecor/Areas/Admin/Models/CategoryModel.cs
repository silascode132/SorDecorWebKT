using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebDecor.DATA.EF;

namespace WebDecor.Areas.Admin.Models
{
    public class CategoryModel
    {
        public string productName { get; set; }
        public long made { get; set; }
        public string info { get; set; }
        public string des { get; set; }
        
        public decimal price { get; set; }
        public decimal sale { get; set; }
        public long category { get; set; }
        public bool freeship { get; set; }
        public byte[] img { get; set; }
        public string imgUrl { get; set; }
        public int sl { get; set; }
        public DateTime dateUpdate { get; set; }
        
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Made> MadeFrom { get; set; }

    }
}