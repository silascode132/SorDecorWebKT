using System;
using System.Linq;
using System.Web.Mvc;
using WebDecor.Common;
using WebDecor.DATA.DAO;
using WebDecor.DATA.EF;

namespace WebDecor.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        private SorDbContext data = null;

        private const string UserID = "UserID";

        public ProfileController()
        {
            data = new SorDbContext();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var id = Session[UserID];
            UserAccount acc = new UserAccount();
            acc = data.UserAccounts.SingleOrDefault(x => x.ID == id.ToString());

            return View(acc);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            UserAccount acc = new UserAccount();

            var userID = Session[UserID].ToString();
            acc.FirstName = collection["firstName"];
            acc.LastName = collection["lastName"];
            acc.Email = collection["Email"];

            if (collection["daycars"].ToString() == "-Ngày-" || collection["monthcars"].ToString() == "-Tháng-" || collection["yearcars"].ToString() == "-Năm-")
            {
                acc.Birthday = null;
            }
            else
            {
                int day = int.Parse(collection["daycars"]);
                int month = int.Parse(collection["monthcars"]);
                int year = int.Parse(collection["yearcars"]);

                DateTime dt = DateTime.Parse(month + "/" + day + "/" + year);
                if (dt > DateTime.Now)
                {
                    ViewBag.WrongBirthDay = "Ngày sinh không hợp lệ!";
                    return this.Index();
                }
                else
                {
                    acc.Birthday = dt;
                }
            }

            if (collection["sexcars"].ToString() == "--Giới tính--")
            {
                acc.Sex = null;
            }
            else
            {
                var s = collection["sexcars"];

                if (s == "Nam")
                {
                    acc.Sex = true;
                }
                else
                {
                    acc.Sex = false;
                }
            }

            if (collection["Address"] == "")
            {
                acc.Diachi = null;
            }
            else
            {
                acc.Diachi = collection["Address"];
            }

            if (collection["Phone"] == "")
            {
                acc.Phone = null;
            }
            else
            {
                acc.Phone = collection["Phone"];
            }

            var dao = new UserDAO();
            if (dao.CheckMail(acc.Email))
            {
                UserAccount account = new UserAccount();
                account = data.UserAccounts.Single(n => n.ID == userID);

                if (acc.Email == account.Email)
                {
                    account.FirstName = acc.FirstName;
                    account.LastName = acc.LastName;
                    account.Birthday = acc.Birthday;
                    account.Sex = acc.Sex;
                    account.Diachi = acc.Diachi;
                    account.Phone = acc.Phone;

                    data.SaveChanges();
                    return RedirectToAction("Index", "Profile");
                }
                else
                {
                    ViewBag.ErrorEmail = "Địa chỉ Email đã tồn tại!";
                    return this.Index();
                }
            }
            else
            {
                UserAccount account = new UserAccount();
                account = data.UserAccounts.Single(n => n.ID == Session[UserID].ToString());
                account.FirstName = acc.FirstName;
                account.LastName = acc.LastName;
                account.Birthday = acc.Birthday;
                account.Sex = acc.Sex;
                account.Diachi = acc.Diachi;
                account.Phone = acc.Phone;
                account.Email = acc.Email;

                data.SaveChanges();
                return RedirectToAction("Index", "Profile");
            }
        }

        public ActionResult MyOrder(int page = 1, int pagesize = 10)
        {
            var dao = new OrderDAO();
            var model = dao.ListPagingForBill(page, pagesize, Session[UserID].ToString());

            return View(model);
        }

        public ActionResult PendingBill(int page = 1, int pagesize = 10)
        {
            var dao = new OrderDAO();
            var model = dao.ListPagingForPending(page, pagesize, Session[UserID].ToString());

            return View(model);
        }

        public ActionResult Shipping(int page = 1, int pagesize = 10)
        {
            var dao = new OrderDAO();
            var model = dao.ListPagingForShipping(page, pagesize, Session[UserID].ToString());

            return View(model);
        }

        public ActionResult Delivered(int page = 1, int pagesize = 10)
        {
            var dao = new OrderDAO();
            var model = dao.ListPagingForDoneShip(page, pagesize, Session[UserID].ToString());

            return View(model);
        }

        public ActionResult ChangedPass()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "PageNotFound");
            }
        }

        [HttpPost]
        public ActionResult ChangedPass(FormCollection collection)
        {
            data = new SorDbContext();
            string userId = Session[UserID].ToString();
            var user = data.UserAccounts.Single(m => m.ID == userId);

            if (collection["newpass"] != collection["repass"])
            {
                ViewBag.Difference = "Xác nhận mật khẩu không đúng!";
                return this.ChangedPass();
            }
            else if (user.Pass != Encryptor.MD5Hash(collection["oldpass"].ToString()))
            {
                ViewBag.WrongPass = "Sai mật khẩu!";
                return this.ChangedPass();
            }
            else
            {
                user.Pass = Encryptor.MD5Hash(collection["newpass"].ToString());
                data.SaveChanges();
                ViewBag.Success = "Đổi mật khẩu thành công!";
                return this.ChangedPass();
            }
        }

        public ActionResult Rate(string idProduct)
        {
            return View();
        }
    }
}