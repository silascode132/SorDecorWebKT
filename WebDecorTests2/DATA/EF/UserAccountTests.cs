using NUnit.Framework;
using System.Security.Cryptography;
using System.Text;
using WebDecor.DBContext;

namespace WebDecor.DATA.EF.Tests
{
    [TestFixture]
    public class UserAccountTests
    {
        [Test]
        public void UserAccountTest()
        {
            UserAccount userAccount = new UserAccount()
            {
                UserName = "test02",
                Pass = "123",
            };
            //Tạo MD5 
            MD5 mh = MD5.Create();
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
    }
}