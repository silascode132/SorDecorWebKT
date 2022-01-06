using Facebook;
using System;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebDecor.Code;
using WebDecor.Common;
using WebDecor.DATA.DAO;
using WebDecor.DATA.EF;
using WebDecor.DBContext;
using WebDecor.Models;

namespace WebDecor.Controllers
{
    public class UserController : Controller
    {
        private SorDbContext context = null;

        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallBack");
                return uriBuilder.Uri;
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            context = new SorDbContext();
            var dao = new UserDAO();

            if (model.userName == null || model.passWord == null)
            {
                ViewBag.Error = "Vui lòng nhập đầy đủ thông tin!";
                return this.Login();
            }
            else
            {
                var result = new AccountModel().Login(model.userName, Encryptor.MD5Hash(model.passWord));
                if (!result)
                {
                    ViewBag.ErrorAcc = "Tên đăng nhập hoặc mật khẩu không chính xác!";
                    return this.Login();
                }
                else
                {
                    if (result && ModelState.IsValid)
                    {
                        SessionHelper.SetSession(new UserSession() { userName = model.userName });
                        var user = dao.GetById(model.userName);
                        var userSession = new UserLogin();

                        var data = context.UserAccounts.Where(s => s.UserName.Equals(model.userName));
                        var dataCartItem = context.Carts.Where(s => s.UserID.Equals(data.FirstOrDefault().ID));

                        userSession.userName = user.UserName;
                        userSession.userID = user.ID;

                        var acc = context.UserAccounts.Single(x => x.UserName == model.userName);
                        Session["Account"] = acc;
                        Session["UserID"] = data.FirstOrDefault().ID;
                        Session["UserName"] = data.FirstOrDefault().UserName;
                        Session["CartItem"] = dataCartItem.FirstOrDefault().ID;

                        Session.Add(CommonConstants.USER_SESSION, userSession);

                        /*FormsAuthentication.SetAuthCookie(model.Email,model.RememberMe); */
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            SorDbContext context = new SorDbContext();
            var dao = new UserDAO();

            var userName = model.userName;
            var name = model.name;
            var email = model.email;
            var pass = model.pass;
            var rePass = model.rePass;

            if (userName == null || name == null || email == null || pass == null || rePass == null)
            {
                ViewBag.Danger = "Vui lòng nhập đầy đủ thông tin!";
            }
            else if (rePass.ToString() != pass.ToString())
            {
                ViewData["ErrorRePass"] = "Mật khẩu nhập lại sai!";
            }
            else if (dao.CheckUserName(userName))
            {
                ViewData["ErrorUserName"] = "Tên đăng nhập đã tồn tại!";
            }
            else if (dao.CheckMail(email))
            {
                ViewData["ErrorMail"] = "Email đã tồn tại!";
            }
            else
            {
                UserAccount acc = new UserAccount();
                acc.ID = "0";
                acc.UserName = userName;
                acc.Pass = Encryptor.MD5Hash(pass);
                acc.Email = email;
                acc.FirstName = null;
                acc.LastName = name;
                acc.Sex = null;
                acc.Phone = null;
                acc.Birthday = null;
                acc.Diachi = null;
                acc.STT = true;

                var res = dao.Insert(acc);
                if (res > 0)
                {
                    ViewBag.Success = "Đăng ký thành công!";
                }
            }
            return this.Register();
        }

        public ActionResult Logout()
        {
            Session["Account"] = null;
            Session["UserID"] = null;
            Session["UserName"] = null;
            Session["CartItem"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ForgotPass()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email"
            });

            return Redirect(loginUrl.AbsoluteUri);
        }

        private string toUnsign(string str)
        {
            string stFormD = str.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < stFormD.Length; i++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[i]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[i]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD));
        }

        private string swapToLowerCharac(string code)
        {
            char[] arr = code.ToCharArray();
            for (int i = 0; i < code.Length; i++)
            {
                if (!Char.IsLower(arr[i]))
                {
                    arr[i] = Char.ToLower(arr[i]);
                }
            }
            string str = new string(arr);
            return str;
        }

        public ActionResult FacebookCallBack(string code)
        {
            var context = new SorDbContext();
            var fb = new FacebookClient();
            dynamic res = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accessToken = res.access_token;
            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                dynamic me = fb.Get("me?fields=link,first_name,middle_name,last_name,id,email");
                string email = me.email;
                string userName;
                string firstName = me.first_name;
                string middleName = me.middle_name;
                string lastName = me.last_name;
                if (email == null)
                {
                    string fname = toUnsign(swapToLowerCharac(firstName));
                    string lname = toUnsign(swapToLowerCharac(lastName));

                    userName = fname + lname + me.id;
                }
                else
                {
                    userName = me.email;
                }

                var acc = new UserAccount();
                acc.UserName = userName;
                acc.Email = email;
                acc.ID = "0";
                acc.FirstName = firstName;
                acc.LastName = middleName + " " + lastName;
                acc.STT = true;
                var result = new UserDAO().InsertFromFacebook(acc);
                if (result > 0)
                {
                    var dao = new UserDAO();
                    var user = dao.GetById(userName);
                    var userSession = new UserLogin();

                    var data = context.UserAccounts.SingleOrDefault(s => s.UserName.Equals(userName));
                    var dataCartItem = context.Carts.SingleOrDefault(s => s.UserID.Equals(data.ID));

                    userSession.userName = user.UserName;
                    userSession.userID = user.ID;

                    var account = context.UserAccounts.Single(x => x.Email == email);
                    //Session["Account"] = acc;
                    //Session["Email"] = data.FirstOrDefault().Email;
                    //Session["UserID"] = data.FirstOrDefault().ID;
                    //Session["UserName"] = data.FirstOrDefault().UserName;
                    //Session["CartItem"] = dataCartItem.FirstOrDefault().ID;

                    Session["Account"] = acc;
                    Session["UserID"] = data.ID;
                    Session["UserName"] = data.FirstName;
                    Session["CartItem"] = dataCartItem.ID;

                    Session.Add(CommonConstants.USER_SESSION, userSession);

                    /*FormsAuthentication.SetAuthCookie(model.Email,model.RememberMe); */
                }
                if (result == 0)
                {
                    var dao = new UserDAO();
                    var userSession = new UserLogin();
                    var user = dao.GetById(userName);
                    var data = context.UserAccounts.Where(s => s.UserName.Equals(userName));
                    var dataCartItem = context.Carts.Where(s => s.UserID.Equals(data.FirstOrDefault().ID));
                    userSession.userName = user.UserName;
                    userSession.userID = user.ID;

                    Session["Account"] = acc;
                    Session["UserID"] = data.FirstOrDefault().ID;
                    Session["UserName"] = data.FirstOrDefault().FirstName;
                    Session["CartItem"] = dataCartItem.FirstOrDefault().ID;
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}