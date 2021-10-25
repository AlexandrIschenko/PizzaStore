using NUnit.Framework;
using PizzaStore;

namespace TestProject1
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

        [TestCase("I4", "aaa")]
        public void IsNameValidTest(double firstArgument, double expectedResult)
        {
            double actualResult = UserValidator.IsNameValid(firstArgument);
            Assert.AreEqual(expectedResult, actualResult);
        }


    }
} 
}