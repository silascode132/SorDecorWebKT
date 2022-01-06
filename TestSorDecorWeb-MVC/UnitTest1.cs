using NUnit.Framework;

namespace TestSorDecorWeb_MVC
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var x = 1;
            var y = 2;  
            var z = 3;  
            var sum = x + y + z;
            if (sum == 6) return;
            else if (sum == 7) return;  

            Assert.Pass();
        }
    }
}