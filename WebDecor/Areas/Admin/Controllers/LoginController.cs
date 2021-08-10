using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDecor.Areas.Admin.Code;
using WebDecor.Areas.Admin.Common;
using WebDecor.Areas.Admin.Models;
using WebDecor.Code;
using WebDecor.Common;
using WebDecor.DATA.DAO;
using WebDecor.DATA.EF;
using WebDecor.DBContext;

namespace WebDecor.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        SorDbContext context = null;
        // GET: Admin/Login
        [HttpGet]   /* Gọi nhận từ URL */
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]      /* Không gọi nhận từ URL */
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginAdminModel model)
        {
            context = new SorDbContext();
            var dao = new UserDAO();
            if (String.IsNullOrEmpty(model.UserName))
            {
                ViewData["ErrorUserName"] = "Không được để trống tên tài khoản!";
            }
            else if (String.IsNullOrEmpty(model.Password))
            {
                ViewData["ErrorPass"] = "Không được để trống mật khẩu!";
            }
            else
            {
                var result = new AccountModel().AdminLogin(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result && ModelState.IsValid)
                {
                    HelperAdminSession.SetSession(new AdminSession() { UserName = model.UserName });
                    var user = dao.GetAdminByID(model.UserName);
                    var userSession = new AdminUserLogin();
                    userSession.userName = user.UserName;
                    userSession.userID = user.ID;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "AdminHome");

                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng!");
                }
                return View(model);
            }
            return this.Index();
        }
        public ActionResult Logout()
        {
            var userSession = new AdminUserLogin();
            userSession.userName = null;
            userSession.userID = null;
            Session.Add(CommonConstants.USER_SESSION, userSession);
            Session.RemoveAll();
            return RedirectToAction("Login", "Admin");
        }


    }
}