using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDecor.Areas.Admin.Data.DAO;
using WebDecor.DATA.EF;

namespace WebDecor.Areas.Admin.Controllers
{
    public class ConfirmOrderController : Controller
    {
        SorDbContext data = null;
        // GET: Admin/Confirm
        public ActionResult Index()
        {
            data = new SorDbContext();
            var delistt = data.OrderBills.Where(x => x.DeliverySTT == true);
            var bill = delistt.Where(x => x.DeliveryDate == null);
            return View(bill);
        }

        public ActionResult UnConfirm(string ID)
        {
            data = new SorDbContext();
            var dao = new PendingOrderDAO().UnConfirmOrder(ID);
            if (dao)
            {
                ModelState.AddModelError("", "Hủy thành công");
            }
            else
            {
                ModelState.AddModelError("", "Lỗi khi hủy đơn!");
            }
            return RedirectToAction("Index", "ConfirmOrder");
        }

        public ActionResult Complete(string ID)
        {
            data = new SorDbContext();
            var dao = new PendingOrderDAO().CompleteDelivery(ID);
            if (dao)
            {
                ModelState.AddModelError("", "Giao thành công");
            }
            else
            {
                ModelState.AddModelError("", "Lỗi khi giao!");
            }
            return RedirectToAction("Index", "ConfirmOrder");
        }
    }
}