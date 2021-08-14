using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDecor.DATA.EF;

namespace WebDecor.DATA.DAO
{
    public class ProductDAO
    {
        private SorDbContext data = null;
        public ProductDAO()
        {
            data = new SorDbContext();
        }

        public IEnumerable<Product> ListAllPaging(int page, int pageSize)
        {
            return data.Products.OrderByDescending(x => x.DateUpdate).ToPagedList(page, pageSize);
        }

        public IEnumerable<Product> ListPagingForCate(int page, int pageSize, int id)
        {
            var product = from Product in data.Products
                          where Product.Category == id
                          select Product;
            return product.OrderByDescending(x => x.SL).ToPagedList(page, pageSize);
        }

        public IEnumerable<Product> ListPaginForPage(int page, int pageSize, decimal min, decimal max)
        {
            var Productmax = data.Products.Where(x => x.Price <= max).ToList();
            var Productmin = Productmax.Where(x => x.Price >= min).ToList();
            return Productmin.OrderByDescending(x => x.Price).ToPagedList(page, pageSize);
        }

        public IEnumerable<Product> ListPagingForSearch(int page, int pageSize, string keyword)
        {
            var lst = data.Products.Where(x => x.ProductName.Contains(keyword)).ToList();
            return lst;
        }
    }
}