using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using WebDecor.DATA.DAO;
using WebDecor.DATA.EF;

namespace WebDecor.Controllers.Tests
{
    [TestClass()]
    public class ProfileControllerTests
    { 
        SorDbContext data = new SorDbContext();
        UserAccount acc = new UserAccount();
        UserAccount account = new UserAccount();

        [TestMethod()]
        public void Successfully_Updated()
        {
            acc.FirstName = "Tran";
            acc.LastName = "Cong Thang";
            int day = 13;
            int month = 2;
            int year = 2000;
            DateTime dt = DateTime.Parse(month + "/" + day + "/" + year);
            acc.Birthday = dt;
            acc.Sex = true;
            acc.Diachi = "Gia Lai";
            acc.Phone = "0123";
            acc.Email = "ct123@gmail.com";
            var dao = new UserDAO();
            if (dao.CheckMail(acc.Email))
            {
                account = data.UserAccounts.Single(n => n.ID == "US00002");
                if (acc.Email != account.Email)
                {
                    account = data.UserAccounts.Single(n => n.ID == "US00002");
                    account.FirstName = acc.FirstName;
                    account.LastName = acc.LastName;
                    account.Birthday = acc.Birthday;
                    account.Sex = acc.Sex;
                    account.Diachi = acc.Diachi;
                    account.Phone = acc.Phone;
                    account.Email = acc.Email;

                    Assert.IsNotNull(data.SaveChanges());
                    Assert.Fail("Thông tin người dùng được cập nhật.");
                }
            }
        }

        [TestMethod()]
        public void Update_Information_When_Email_Already_Exists()
        {
            SorDbContext data = new SorDbContext();
            UserAccount acc = new UserAccount();
            acc.FirstName = "Tran";
            acc.LastName = "Cong Thang";
            int day = 13;
            int month = 2;
            int year = 2000;
            DateTime dt = DateTime.Parse(month + "/" + day + "/" + year);
            acc.Birthday = dt;
            acc.Sex = true;
            acc.Diachi = "Gia Lai";
            acc.Phone = "0123";
            acc.Email = "ct123@gmail.com";
            var dao = new UserDAO();
            if (dao.CheckMail(acc.Email))
            {
                UserAccount account = new UserAccount();
                account = data.UserAccounts.Single(n => n.ID == "US00002");
                

                if (acc.Email == account.Email)
                {
                    Assert.Fail("Địa chỉ Email đã tồn tại.");
                    Assert.Fail("Không cập nhật thông tin người dùng.");
                    Assert.IsNull(data.SaveChanges());
                } 
            }
        }

        [TestMethod()]
        public void Update_Information_When_First_Name_Is_Blank()
        {
            {
                SorDbContext data = new SorDbContext();
                UserAccount acc = new UserAccount();
                acc.FirstName = "";
                acc.LastName = "Cong Thang";
                int day = 13;
                int month = 2;
                int year = 2000;
                DateTime dt = DateTime.Parse(month + "/" + day + "/" + year);
                acc.Birthday = dt;
                acc.Sex = true;
                acc.Diachi = "Gia Lai";
                acc.Phone = "0123";
                acc.Email = "ct123@gmail.com";
                var dao = new UserDAO();
                if (dao.CheckMail(acc.Email))
                {
                    UserAccount account = new UserAccount();
                    account = data.UserAccounts.Single(n => n.ID == "US00002");
                    if (acc.Email != account.Email)
                    {
                        if (acc.FirstName == null || acc.FirstName == "")
                        {
                            Assert.Fail("Vui lòng điền vào trường này.");
                        }
                        else
                        {
                            account = data.UserAccounts.Single(n => n.ID == "US00002");
                            account.FirstName = acc.FirstName;
                            account.LastName = acc.LastName;
                            account.Birthday = acc.Birthday;
                            account.Sex = acc.Sex;
                            account.Diachi = acc.Diachi;
                            account.Phone = acc.Phone;
                            account.Email = acc.Email;
                            Assert.Fail("Thông tin người dùng được cập nhật.");
                        }
                    }              
                }
            }
        }

        [TestMethod()]
        public void Update_Information_When_Last_Name_Is_Blank()
        {
            {
                SorDbContext data = new SorDbContext();
                UserAccount acc = new UserAccount();
                acc.FirstName = "Tran";
                acc.LastName = "";
                int day = 13;
                int month = 2;
                int year = 2000;
                DateTime dt = DateTime.Parse(month + "/" + day + "/" + year);
                acc.Birthday = dt;
                acc.Sex = true;
                acc.Diachi = "Gia Lai";
                acc.Phone = "0123";
                acc.Email = "ct123@gmail.com";
                var dao = new UserDAO();

               
            }
        }
    }
}