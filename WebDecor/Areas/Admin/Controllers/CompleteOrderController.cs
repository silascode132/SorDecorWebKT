using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDecor.DATA.EF;

namespace WebDecor.Areas.Admin.Controllers
{
    public class CompleteOrderController : Controller
    {
        SorDbContext data = null;
        // GET: Admin/CompleteOrder
        public ActionResult Index()
        {
            data = new SorDbContext();
            var delistt = data.OrderBills.Where(x => x.DeliverySTT == true);
            var bill = delistt.Where(x => x.DeliveryDate != null);
            return View(bill);
        }
    }
}