using NUnit.Framework;
using PizzaStore;

namespace TestProject_Pizza
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(5, 5)]
        public void IsAmountValidTest(double firstArgument, double expectedResult)
        {
            double actualResult = UserValidator.IsAmountValid(firstArgument);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}