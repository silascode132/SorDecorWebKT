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
                ViewBag.Danger = "Vui lòng nh?p ??y ?? thông tin!";
            }
            else if (rePass.ToString() != pass.ToString())
            {
                ViewData["ErrorRePass"] = "M?t kh?u nh?p l?i sai!";
            }
            else if (dao.CheckUserName(userName))
            {
                ViewData["ErrorUserName"] = "Tên ??ng nh?p ?ã t?n t?i!";
            }
            else if (dao.CheckMail(email))
            {
                ViewData["ErrorMail"] = "Email ?ã t?n t?i!";
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
                    ViewBag.Success = "??ng ký thành công!";
                }
            }
            return this.Register();
        }
    }
}