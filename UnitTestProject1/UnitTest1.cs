using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string x = "It is worth paying more attention to learning!";
            ConsoleApp1.Student v1 = new ConsoleApp1.Student();
            v1.name = "Вася";
            v1.lastname = "Герой";
            v1.group = "IT-14";
            v1.year = 2017;
            v1.address = "305 Blakemore Ln, Winchester, KY, 40391";
            v1.passport = "9001";
            v1.age = 21;
            v1.telephone = "(904) 693-0135";
            v1.rating = 74;
            string result = v1.StudentRating(v1.rating);
            Assert.AreEqual(x, result);
        }
    }
}