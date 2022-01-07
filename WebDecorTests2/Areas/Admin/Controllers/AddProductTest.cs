using NUnit.Framework;
using System.Drawing;
using System.IO;
using WebDecor.Areas.Admin.Controllers;
using WebDecor.Areas.Admin.Models;
using WebDecor.DATA.EF;

namespace WebDecorTests2.Areas.Admin.Controllers

{
    [TestFixture]
    
    public class AddProductTest
    {
        public byte[] imgToByteArray(Image img)
        {
            using (MemoryStream mStream = new MemoryStream())
            {
                img.Save(mStream, img.RawFormat);
                return mStream.ToArray();
            }
        }


     

        [Test]
        public void Add_Product_Success()
        {

          

            Image img = Image.FromFile("D:\\aobaoho.png");
            byte[] bArr = imgToByteArray(img);

            Product product = new Product()
            {
                
                ProductName = "Áo bảo hộ",
                Made = 1,
                Info = "Áo bảo hộ",
                Descript = "Áo bảo hộ",
                Price = 200000,
                Category = 1,
                Sale = 0,
                Image = bArr,
                SL = 99,
                Freeship = false,
                DateUpdate = System.DateTime.Now
            };

          
          
        }
    }
}