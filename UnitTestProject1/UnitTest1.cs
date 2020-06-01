using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Lab04_1.Student student = new Lab04_1.Student();
            int Rating = 70;
            int result = student.StudentRating(Rating);
            Assert.AreEqual(3,result);
        }
    }

}
