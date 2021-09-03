using Newtonsoft.Json;
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
        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
        // GET: Admin/Home
        public AdminHomeController()
        {
            data = new SorDbContext();

        }
        public ActionResult Index()
        {
            decimal revenueMonth = new StatisDAO().RevenueMonth();
            ViewBag.revenueMonth = revenueMonth;
            decimal revenueYear = new StatisDAO().RevenueYear();
            ViewBag.revenueYear = revenueYear;
            int pending = data.OrderBills.Count(x => x.DeliverySTT == false);
            ViewBag.PendingTask = pending;
            int feedback = data.Feedbacks.Count();
            ViewBag.Feedback = feedback;

            ViewBag.DataPoints = JsonConvert.SerializeObject(DataService.GetData(), _jsonSetting);


            return View();
        }
    }
}