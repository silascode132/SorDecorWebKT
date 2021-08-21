using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDecor.Areas.Admin.Data.DAO;
using WebDecor.DATA.EF;

namespace WebDecor.Areas.Admin.Controllers
{
    public class PendingOrderController : Controller
    {
        private SorDbContext data = null;
        // GET: Admin/PendingOrder
        public ActionResult Index()
        {
            data = new SorDbContext();
            var bill = data.OrderBills.Where(x => x.DeliverySTT == false).ToList();
            return View(bill);
        }


        [HttpGet]
        public ActionResult OrderInfo(string ID)
        {
            data = new SorDbContext();
            var bill = data.OrderInfoes.Where(x => x.ItemOrder.Equals(ID)).ToList();

            var info = data.OrderBills.Single(x => x.ID == ID);
            ViewBag.UserName = info.UserName;
            ViewBag.Addresss = info.UserAddress;
            ViewBag.Phone = info.Phone;
            ViewBag.Note = info.Note;
            ViewBag.DateOrder = info.DateOrder;
            ViewBag.IDOrder = ID;
            ViewBag.SL = data.OrderInfoes.Where(x => x.ItemOrder == ID).Count();
            return View(bill);
        }
        
        public ActionResult Confirm(string ID)
        {
            data = new SorDbContext();
            var dao = new PendingOrderDAO().ConfirmOrder(ID);
            if (dao)
            {
                ModelState.AddModelError("", "Xác nhận đơn hàng thành công");
            }
            else
            {
                ModelState.AddModelError("", "Lỗi khi xác nhận đơn hàng!");
            }
            return RedirectToAction("Index", "PendingOrder");
        }
        
    }
}