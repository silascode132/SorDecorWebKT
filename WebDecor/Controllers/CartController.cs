using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDecor.DATA.DAO;
using WebDecor.DATA.EF;
using WebDecor.Models;

namespace WebDecor.Controllers
{
    public class CartController : Controller
    {
        
        private const string CartItem = "CartItem";
        private SorDbContext data = null;

        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }
            else
            {
                data = new SorDbContext();
                var cart = Session[CartItem];   //Lấy ID Cart
                var product = data.ItemInCarts.Where(x => x.CartItemID == cart.ToString()); //Lấy cart ra

                ViewBag.TongTienTP = TongTienTP();
                ViewBag.TongTien = TongTien();
                ViewBag.TongSL = TongSL();
                return View(product);
            }
        }

        //Số lượng item có trong giỏ
        public ActionResult CartItemPartial()
        {
            ViewBag.TongSL = TongSL();
            return PartialView();
        }

        
        private int TongSL()
        {
            data = new SorDbContext();
            int tongSL = 0;
            var cart = Session[CartItem];

            if (data.ItemInCarts.Where(x => x.CartItemID == cart.ToString()).Count() > 0)
            {
                int product = int.Parse(data.ItemInCarts.Where(x => x.CartItemID == cart.ToString()).Sum(x => x.SL).ToString());
                tongSL = product;
            }
            else
            {
                tongSL = 0;
            }
            

            //tongSL = product.Sum(x=>x.SL);
            return tongSL;
        }

        private decimal TongTienTP()
        {
            decimal Tong = 0;
            if (TongSL() == 0)
            {
                return Tong;
            }
            else
            {
                data = new SorDbContext();
                var cart = Session[CartItem];

                var lst = data.ItemInCarts.Where(x => x.CartItemID == cart.ToString());  //Tạo list những SP có trong giỏ
                foreach (var item in lst)
                {
                    string id = item.ProductID;
                    int sl = int.Parse(item.SL.ToString()); //Lấy SL của SP đó
                    var product = data.Products.Single(x => x.ID == id);    // Lấy giá từ bảng Product

                    Tong += decimal.Parse((product.Price - ((product.Price * product.Sale) / 100)).ToString());
                }
                return Tong;
            }
            
        }

        private decimal TongTien()
        {
            decimal Tong = 0;
            if (TongSL() == 0)
            {
                return Tong;
            }
            else
            {
                data = new SorDbContext();
                var cart = Session[CartItem];

                var lst = data.ItemInCarts.Where(x => x.CartItemID == cart.ToString());  //Tạo list những SP có trong giỏ
                foreach (var item in lst)
                {
                    string id = item.ProductID;
                    int sl = int.Parse(item.SL.ToString());
                    var product = data.Products.Single(x => x.ID == id);    // Lấy giá từ bảng Product

                    Tong += decimal.Parse(((product.Price - ((product.Price * product.Sale) / 100)) * sl).ToString());
                }
                return Tong;
            }
        }

        //THêm SP vào giỏ
        public ActionResult AddItem(string productId, int SL)
        {
            data = new SorDbContext();
            var cart = Session[CartItem];
            if (cart != null)   // Kiểm tra người dùng đã đăng nhập chưa
            {
                ItemInCart item = new ItemInCart();
                
                item.ID = "0";
                item.ProductID = productId;
                var price = data.Products.Where(x => x.ID == productId).FirstOrDefault().Price;
                var dis = data.Products.Where(x => x.ID == productId).FirstOrDefault().Sale;
                item.Price = (decimal)(price - (price * dis) / 100);
                item.SL = SL;
                item.CartItemID = cart.ToString();

                data.ItemInCarts.Add(item);
                data.SaveChanges();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
            return Redirect("#");
        }

        //Xóa 1 SP khỏi giỏ
        public ActionResult DeleteItem(string ID)
        {
            var cart = Session[CartItem];
            var res = new CartItemModel().DeleteItem(ID, cart.ToString());
            if (res)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //Update SL của 1 SP
        public ActionResult UpdateItem(FormCollection collection)
        {
            var cart = Session[CartItem];
            data = new SorDbContext();
            var dao = new CartItemDAO();

            var lst = data.ItemInCarts.Where(x => x.CartItemID == cart.ToString());     // Lấy ra list SP trong giỏ của user
            foreach (var item in lst)
            {
                string id = "SL" + item.ProductID; //Lấy collection ID
         
                var sl = Convert.ToInt32(collection[id].ToString()); //Lấy số lượng người dùng nhập

                if (sl == 0 || sl.Equals(""))
                {
                    var res = new CartItemModel().DeleteItem(item.ProductID, cart.ToString());  //Xóa item
                } 
              
                else
                {
                    string cartid = cart.ToString();
                    bool res = dao.UpdateItem(item.ProductID, sl, cartid);
                }
                
            }
            return RedirectToAction("Index", "Cart");
        }
    }
}