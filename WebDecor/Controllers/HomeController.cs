using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDecor.Areas.Admin.Common;
using WebDecor.Code;
using WebDecor.DATA.DAO;
using WebDecor.DATA.EF;
using WebDecor.DBContext;
using WebDecor.Models;

namespace WebDecor.Controllers
{

    public class HomeController : Controller
    {
        private SorDbContext data = null;
        public HomeController()
        {
            data = new SorDbContext();
        }

        public ActionResult Index(int page = 1, int pageSize = 16)
        {
            var dao = new ProductDAO();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        
        
        public ActionResult ProductDetails(string id)
        {
            data = new SorDbContext();
            var model = new ProductDetailsModel();
            var product = data.Products.SingleOrDefault(x => x.ID == id);
            var cate = data.Categories.SingleOrDefault(x => x.ID == product.Category).CategoryName;
            var made = data.Mades.SingleOrDefault(x => x.ID == product.Made).MadeName;

            model.productID = product.ID;
            model.productName = product.ProductName;
            model.made = made;
            model.info = product.Info;
            model.des = product.Descript;
            model.price = (decimal)product.Price;
            if (product.Size == null)
            {
                model.size = 0;
            }
            else
            {
                model.size = (long)product.Size;
            }
            model.sale = product.Sale;
            model.category = cate;
            model.freeShip = (bool)product.Freeship;
            model.imageURL = product.ImageUrl;
            model.sL = product.SL;
            model.stt = product.STT;

            return View(model);
        }
        public ActionResult Shop(int page = 1, int pageSize = 9)
        {
            var dao = new ProductDAO();
            var model = dao.ListAllPaging(page, pageSize);

            return View(model);
        }

        public ActionResult Category()
        {
            //var cate = from Category in data.Categories
            //               select Category;

            var category = data.Categories.ToList();

            return PartialView(category);
        }

        public ActionResult RecommendProduct()
        {
            

            return PartialView();
        }

        public ActionResult ProductForCate(int id)
        {
            int page = 1;
            int pageSize = 9;
            var dao = new ProductDAO();
            var model = dao.ListPagingForCate(page, pageSize, id);

            return View(model);
            //return View();
        }

        [HttpPost]
        public ActionResult ProductForPrice(FormCollection collection)
        {
            int page = 1;
            int pagesize = 9;
            var dao = new ProductDAO();
            decimal num1 = decimal.Parse(collection["min"].ToString());
            decimal num2 = decimal.Parse(collection["max"].ToString());
            decimal min, max;
            min = num1;
            max = num2;
            if (num1 > num2)
            {
                min = num2;
                max = num1;
            }
            var model = dao.ListPaginForPage(page, pagesize, min, max);

            return View(model);
        }
        [HttpGet]
        public ActionResult Search(FormCollection collection)
        {
            int page = 1;
            int pagesize = 9;
            var key = collection["textKeyword"];
            var dao = new ProductDAO();
            var model = dao.ListPagingForSearch(page, pagesize, key);

            return View(model);
        }
    }
}