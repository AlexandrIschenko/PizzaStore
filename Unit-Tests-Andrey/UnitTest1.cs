using NUnit.Framework;
using PizzaStore;

namespace Unit_Tests_Andrey
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(10, 2, 12)]
        [TestCase(0, 0, 0)]
        [TestCase(0, 1, 1)]
        [TestCase(1, 0, 1)]
        [TestCase(-10, -2, -12)]
        [TestCase(-1, 2, 1)]
        //[TestCase (-1,-2,0)]
        public void PlusArgumentsTest(double firstArgument, double secondArgument, double expectedResult)
        {
            double actualResult = Menu.MakeOrder(firstArgument, secondArgument);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}