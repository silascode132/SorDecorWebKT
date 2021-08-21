using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDecor.Areas.Admin.Models;
using WebDecor.DATA.EF;


namespace WebDecor.Areas.Admin.Controllers
{
    [System.Runtime.InteropServices.Guid("F26F5169-B628-4D02-BB11-C166B9A7DA82")]
    public class ProductController : AdminBaseController
    {
        private SorDbContext data = null;
        public ActionResult Index()
        {
            data = new SorDbContext();

            var products = data.Products.OrderByDescending(x => x.ID);
            List<ProductModel> lst = new List<ProductModel>();
            foreach (var item in products)
            {
                ProductModel model = new ProductModel();
                model.id = item.ID;
                model.productName = item.ProductName;
                model.made = data.Mades.FirstOrDefault(x => x.ID == item.Made).MadeName;
                model.info = item.Info;
                model.des = item.Descript;
                model.price = (decimal)item.Price;
                model.sale = item.Sale;
                model.category = data.Categories.FirstOrDefault(x => x.ID == item.Category).CategoryName;
                model.freeship = item.Freeship;
                model.img = item.ImageUrl;
                model.sl = item.SL;
                model.stt = item.STT;
                lst.Add(model);
            }
            return View(lst);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            data = new SorDbContext();
            var model = new CategoryModel
            {
                Categories = data.Categories.ToList(),
                MadeFrom = data.Mades.ToList(),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, CategoryModel model, HttpPostedFileBase file)
        {
            data = new SorDbContext();
            var Name = model.productName;
            var Made = model.made;
            var Info = model.info;
            var Des = model.des;
            var Price = model.price;
            var Sale = model.sale;
            var Category = model.category;
            var Freship = model.freeship;
            var SL = model.sl;
            DateTime date = DateTime.Now;


            if (model.productName == null || model.info == null || model.des == null || model.price.ToString() == null)
            {
                ViewBag.WrongInput = "Nhập đầy đủ thông tin sản phẩm!";
                return this.Create();
            }
            else if (model.made == 0)
            {
                ViewBag.WrongMade = "Nhập nơi cung cấp sản phẩm";
                return this.Create();
            }
            else if (model.category == 0)
            {
                ViewBag.WrongCate = "Nhập danh mục sản phẩm";
                return this.Create();
            }
            else if (model.price < 0)
            {
                ViewBag.WrongPrice = "Giá sản phẩm nhập sai!";
                return this.Create();
            }
            else if (model.sale < 0 || model.sale > 100)
            {
                ViewBag.WrongSale = "Giảm giá sai!";
                return this.Create();
            }
            else if (file == null || file.ContentLength <= 0)
            {
                ViewBag.WrongImg = "Lỗi hình ảnh!";
                return this.Create();
            }
            else
            {
                product.Image = new byte[file.ContentLength];
                file.InputStream.Read(product.Image, 0, file.ContentLength);
                string fileName = System.IO.Path.GetFileName(file.FileName);
                string urlImg = Server.MapPath("~/Assets/Client/img/product/" + fileName);
                file.SaveAs(urlImg);

                product.ImageUrl = fileName;

                product.ID = "0";
                product.ProductName = Name;
                product.Info = Info;
                product.Descript = Des;
                product.Price = Price;
                if (model.sale.ToString() == null)
                {
                    product.Sale = 0;
                }
                else
                {
                    product.Sale = Sale;
                }
                //product.Images = Images;
                product.SL = SL;
                product.STT = true;
                product.DateUpdate = date;
                product.Category = Category;
                product.Made = Made;

                data.Products.Add(product);
                data.SaveChanges();
                ViewBag.Success = "Thêm sản phẩm thành công!";
                return this.Create();
            }

        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            data = new SorDbContext();
            Product product = data.Products.SingleOrDefault(x => x.ID == id);

            var test = id;
            var model = new ProductEditModel
            {
                productID = product.ID,
                productName = product.ProductName,
                mades = data.Mades.ToList(),
                categories = data.Categories.ToList(),
                productInfo = product.Info,
                productDes = product.Descript,
                productPrice = (decimal)product.Price,
                productSale = (decimal)product.Sale,
                productSL = product.SL,
                category = product.Category,
                made = product.Made,
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ProductEditModel model)
        {

            if (model.productName == "" || model.productName == null)
            {
                ViewBag.WrongName = "Nhập tên sản phẩm";
                return this.Edit(model.productID);
            }
            else if (model.made == 0)
            {
                ViewBag.WrongMade = "Chọn nơi xuất xứ";
                return this.Edit(model.productID);
            }
            else if (model.category == 0)
            {
                ViewBag.WrongCate = "Chọn danh mục sản phẩm";
                return this.Edit(model.productID);
            }
            else
            {
                data = new SorDbContext();
                string id = model.productID;
                Product product = data.Products.Single(x => x.ID.Equals(id));
                product.ProductName = model.productName;
                product.Info = model.productInfo;
                product.Descript = model.productDes;
                product.Price = model.productPrice;
                product.Sale = model.productSale;
                product.SL = model.productSL;

                data.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
        }


        public ActionResult Delete(string id)
        {
            data = new SorDbContext();
            Product product = data.Products.Single(x => x.ID == id);
            product.STT = false;
            data.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
