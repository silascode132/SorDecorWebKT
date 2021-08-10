using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDecor.DATA.EF;

namespace WebDecor.Areas.Admin.Controllers
{
    public class FeedbackController : Controller
    {
        SorDbContext data = null;
        
        public ActionResult Index()
        {
            data = new SorDbContext();
            var bill = data.Feedbacks.Where(x => x.STT == false).ToList();

            return View(bill);
        }

        
        public ActionResult Done(int id)
        {
            data = new SorDbContext();

            var b = data.Feedbacks.Single(x => x.ID == id);

            b.STT = true;
            data.SaveChanges();

            return RedirectToAction("Index", "Feedback");
        }

        public ActionResult ListFeedback()
        {
            data = new SorDbContext();

            var lst = data.Feedbacks.ToList();

            return View(lst);
        }
    }
}