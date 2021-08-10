using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDecor.DATA.EF;

namespace WebDecor.DBContext
{
    public class ProductModel
    {
        private SorDbContext context = null;
        public ProductModel()
        {
            context = new SorDbContext();
        }

        public List<Product> ListAll()
        {
            var list = context.Database.SqlQuery<Product>("sp_Product_ListAll").ToList();
            return list;
        }
    }
}