using NUnit.Framework;
using System.Security.Cryptography;
using System.Text;
using WebDecor.DATA.EF;

namespace WebDecor.DBContext.Tests
{
    [TestFixture]
    public class AccountModelTests
    {
        [Test]
        public void LoginTest()
        {
            
            UserAccount userAccount = new UserAccount()
            {
                UserName = "test02",
                Pass = "123"
        };

            //Tạo MD5 
            MD5 mh = MD5.Create();
            //Chuyển kiểu chuổi thành kiểu byte
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(userAccount.Pass);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            var account = new AccountModel();
            var result = account.Login(userAccount.UserName, userAccount.Pass = sb.ToString());

            Assert.That(result, Is.True);
        }

        [Test]
        public void Log_In_With_Your_Username_Blank()
        {
            UserAccount userAccount = new UserAccount()
            {
                UserName = "",
                Pass = "123"
            };

            //Tạo MD5 
            MD5 mh = MD5.Create();
            //Chuyển kiểu chuổi thành kiểu byte
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(userAccount.Pass);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            var account = new AccountModel();
            var result = account.Login(userAccount.UserName, userAccount.Pass = sb.ToString());

            Assert.That(result, Is.False);
        }

        [Test]
        public void Log_In_With_Your_Password_Blank()
        {
            UserAccount userAccount = new UserAccount()
            {
                UserName = "test02",
                Pass = ""
            };

            //Tạo MD5 
            MD5 mh = MD5.Create();
            //Chuyển kiểu chuổi thành kiểu byte
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(userAccount.Pass);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            var account = new AccountModel();
            var result = account.Login(userAccount.UserName, userAccount.Pass = sb.ToString());

            Assert.That(result, Is.False);
        }

        [Test]
        public void Log_In_With_Your_Username_And_Password_Blank()
        {
            UserAccount userAccount = new UserAccount()
            {
                UserName = "",
                Pass = ""
            };

            //Tạo MD5 
            MD5 mh = MD5.Create();
            //Chuyển kiểu chuổi thành kiểu byte
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(userAccount.Pass);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            var account = new AccountModel();
            var result = account.Login(userAccount.UserName, userAccount.Pass = sb.ToString());

            Assert.That(result, Is.False);
        }

        [Test]
        public void Login_With_Unregistered_Account()
        {
            UserAccount userAccount = new UserAccount()
            {
                UserName = "test0000001",
                Pass = "123213"
            };

            //Tạo MD5 
            MD5 mh = MD5.Create();
            //Chuyển kiểu chuổi thành kiểu byte
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(userAccount.Pass);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            var account = new AccountModel();
            var result = account.Login(userAccount.UserName, userAccount.Pass = sb.ToString());

            Assert.That(result, Is.False);
        }

        [Test]
        public void Login_With_Incorrect_Password()
        {
            UserAccount userAccount = new UserAccount()
            {
                UserName = "test02",
                Pass = "111111"
            };

            //Tạo MD5 
            MD5 mh = MD5.Create();
            //Chuyển kiểu chuổi thành kiểu byte
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(userAccount.Pass);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            var account = new AccountModel();
            var result = account.Login(userAccount.UserName, userAccount.Pass = sb.ToString());

            Assert.That(result, Is.False);
        }


        [Test]
        public void AdminLoginTest()
        {
            Admin admin = new Admin()
            {
                UserName = "admin",
                Pass = "123"
            };
            //Tạo MD5 
            MD5 mh = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(admin.Pass);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            var account = new AccountModel();
            var result = account.AdminLogin(admin.UserName, admin.Pass = sb.ToString());

            Assert.That(result, Is.True);
        }
    }
}