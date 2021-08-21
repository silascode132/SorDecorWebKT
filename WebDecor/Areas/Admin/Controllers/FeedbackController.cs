using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDecor.Common;
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

        [HttpGet]
        public ActionResult SendFeedBack(long id)
        {
            data = new SorDbContext();
            string email = data.Feedbacks.SingleOrDefault(x => x.ID == id).Email;
            string username = data.Feedbacks.SingleOrDefault(x => x.ID == id).Name;

            ViewBag.email = email;
            ViewBag.name = username;
            ViewBag.id = id;

            return View();
        }

        [HttpPost]
        public ActionResult SendFeedBack(FormCollection collection)
        {
            data = new SorDbContext();
            long id = long.Parse(collection["ID"].ToString());
            var feed = data.Feedbacks.Single(x => x.ID == id);

            string content = System.IO.File.ReadAllText(Server.MapPath("~/Template/RepFeedback.html"));

            content = content.Replace("{{CustomerName}}", collection["UserName"]);
            content = content.Replace("{{CustomerContent}}", collection["Content"]);

            new MailHelper().SendMail(collection["Email"], "Phản hồi về đóng góp của người dùng", content);

            feed.STT = true;
            data.SaveChanges();

            return RedirectToAction("Index", "Feedback");
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