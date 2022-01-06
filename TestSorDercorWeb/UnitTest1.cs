using NUnit.Framework;

namespace TestSorDercorWeb
{
    public class Tests : UserController
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        public void Test_Register(RegisterModel model)
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
                ViewBag.Danger = "Vui l�ng nh?p ??y ?? th�ng tin!";
            }
            else if (rePass.ToString() != pass.ToString())
            {
                ViewData["ErrorRePass"] = "M?t kh?u nh?p l?i sai!";
            }
            else if (dao.CheckUserName(userName))
            {
                ViewData["ErrorUserName"] = "T�n ??ng nh?p ?� t?n t?i!";
            }
            else if (dao.CheckMail(email))
            {
                ViewData["ErrorMail"] = "Email ?� t?n t?i!";
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
                    ViewBag.Success = "??ng k� th�nh c�ng!";
                }
            }
            return this.Register();
        }
    }
}