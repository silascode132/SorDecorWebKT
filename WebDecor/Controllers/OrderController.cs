using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDecor.Common;
using WebDecor.DATA.DAO;
using WebDecor.DATA.EF;

namespace WebDecor.Controllers
{
    public class OrderController : Controller
    {
        private SorDbContext data = null;
        private const string CartItem = "CartItem";
        public OrderController()
        {
            data = new SorDbContext();
        }
        private int TongSL()
        {
            int tongSL = 0;
            var cart = Session[CartItem];

            if (data.ItemInCarts.Where(x => x.CartItemID == cart.ToString()).Count() > 0)
            {
                tongSL = int.Parse(data.ItemInCarts.Where(x => x.CartItemID == cart.ToString()).Sum(x => x.SL).ToString());
            }
            else
            {
                tongSL = 0;
            }

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
        // GET: Order
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }
            else
            {
                var cart = Session[CartItem];

                //var productCart = from ItemInCart in data.ItemInCarts
                //                  where ItemInCart.CartItemID == cart.ToString()
                //                  select ItemInCart;

                var product = data.ItemInCarts.Where(x => x.CartItemID == cart.ToString());

                ViewBag.TongTienTP = TongTienTP();
                ViewBag.TongTien = TongTien();
                return View(product);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection collection)
        {
            var cart = Session[CartItem];
            data = new SorDbContext();
            DateTime dt = DateTime.Now;
            decimal total = 0;

            OrderBill orderBill = new OrderBill();
            UserAccount acc = (UserAccount)Session["Account"];
            orderBill.UserID = acc.ID;
            orderBill.UserName = collection["UserName"];
            orderBill.UserAddress = collection["Address"];
            orderBill.Phone = collection["Phone"];
            orderBill.Email = collection["Email"];

            if (collection["Note"] == "")
            {
                orderBill.Note = "NULL";
            }
            else
            {
                orderBill.Note = collection["Note"];
            }
            orderBill.Paid = false;
            orderBill.DeliverySTT = false;
            orderBill.DateOrder = dt;
            orderBill.DeliveryDate = null;


            var lst = data.ItemInCarts.Where(x => x.CartItemID == cart.ToString()).ToList();
            int check = 0;
            int iSL = 0;
            for (int i = 0; i < lst.Count(); i++)
            {
                string productID = lst[i].ProductID;
                iSL = data.Products.FirstOrDefault(x => x.ID == productID).SL;
                if (lst[i].SL > iSL)
                {
                    check = 1;
                    ViewBag.WrongSL = "Số lượng sản phẩm trong cửa hàng không đủ!";
                    break;
                }
            }

            if (check != 0)
            {
                return this.Index();
            }
            else
            {
                string id = new OrderDAO().AddOrder(orderBill);
                if (id != null)
                {
                    foreach (var item2 in lst)
                    {
                        OrderInfo orderitem = new OrderInfo();
                        orderitem.ItemOrder = id;
                        orderitem.ProductID = item2.ProductID;
                        orderitem.SL = int.Parse(item2.SL.ToString());
                        orderitem.Total = decimal.Parse((item2.Total * item2.SL).ToString());

                        total += orderitem.Total;
                        data.OrderInfoes.Add(orderitem);
                        data.ItemInCarts.Remove(item2);

                    }

                    data.SaveChanges();
                    var update = new OrderDAO().UpdateSL(id);

                    


                    return RedirectToAction("ConfirmOrder", "Order");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

        }

        public ActionResult ConfirmOrder()
        {
            return View();
        }

        [HttpGet]
        public ActionResult InfoOrder(string ID)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "PageNotFound");
            }
            else
            {
                data = new SorDbContext();
                var userID = Session["UserID"];
                var us = data.OrderBills.SingleOrDefault(x => x.ID == ID).UserID;

                if (us != Session["UserID"].ToString())
                {
                    return RedirectToAction("Index", "PageNotFound");
                }
                else
                {
                    var bill = data.OrderInfoes.Where(x => x.ItemOrder.Equals(ID));
                    var info = data.OrderBills.Single(x => x.ID == ID);
                    ViewBag.UserName = info.UserName;
                    ViewBag.Addresss = info.UserAddress;
                    ViewBag.Phone = info.Phone;
                    if (info.Note == "NULL")
                    {
                        ViewBag.Note = "Không có";
                    }
                    else
                    {
                        ViewBag.Note = info.Note;
                    }
                    ViewBag.DateOrder = info.DateOrder;
                    ViewBag.IDOrder = ID;
                    return View(bill);
                }
            }
        }
    }
}