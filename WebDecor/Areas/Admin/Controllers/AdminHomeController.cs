using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDecor.Areas.Admin.Common;
using WebDecor.Areas.Admin.Data.DAO;
using WebDecor.Areas.Admin.Models;
using WebDecor.Code;
using WebDecor.DATA.EF;

namespace WebDecor.Areas.Admin.Controllers
{
    public class AdminHomeController : AdminBaseController
    {
        SorDbContext data = null;
        // GET: Admin/Home
        public AdminHomeController()
        {
            data = new SorDbContext();
        }
        public ActionResult Index()
        {
            //decimal revenueMonth = new StatisDAO().RevenueMonth();
            //ViewBag.revenueMonth = revenueMonth;
            //decimal revenueYear = new StatisDAO().RevenueYear();
            //ViewBag.revenueYear = revenueYear;
            //int pending = data.OrderBills.Count(x => x.DeliverySTT == false);
            //ViewBag.PendingTask = pending;
            //int feedback = data.Feedbacks.Count();
            //ViewBag.Feedback = feedback;


            //RevenuePerMonthModel model = new RevenuePerMonthModel();
            //int today = DateTime.Now.Day;
            //var x = data.Admins.Where(m => m.ID == Session["UserID"].ToString());
            //var y = x.Where(m=>m.RoleAdmin==)
            //for (int i = 0; i < today; i++)
            //{
            //    model.day = i + 1;
            //    model.revenue = 
            //}
            
            //try
            //{
            //    //ViewBag.
            //}
            //catch (Exception)
            //{

            //    throw;
            //}


            return View();
        }
    }
}