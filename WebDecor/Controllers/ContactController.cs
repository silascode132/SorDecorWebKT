using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDecor.DATA.DAO;
using WebDecor.DATA.EF;

namespace WebDecor.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Send(string name, string phone, string email, string content)
        {
            if (Session["UserID"] == null)
            {
                return Json(new
                {
                    status = false
                });
            }
            else
            {
                var feedback = new Feedback();
                feedback.UserID = Session["UserID"].ToString();
                feedback.Name = name;
                feedback.Phone = phone;
                feedback.Email = email;
                feedback.Content = content;
                feedback.CreatedDate = DateTime.Now;
                feedback.STT = false;

                long id = new ContactDAO().InsertFeedBack(feedback);
                if (id > 0)
                {
                    return Json(new
                    {
                        status = true
                    });
                }
                else
                {
                    return Json(new
                    {
                        status = false
                    });
                }
            }
        }
    }
}