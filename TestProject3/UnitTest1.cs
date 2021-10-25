using NUnit.Framework;
using PizzaStore;
using PizzaStore.Services;
using PizzaStore.Validators;
using PizzaStore.Models;

namespace TestProject3
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(5, 5)]
        public void IsAmountValidTest(double amount, bool expectedResult)
        {
           bool actualResult = UserValidator.IsAmountValid(amount);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("I4", "aaa")]
        public void IsNameValidTest(string name, double expectedResult)
        {
            bool actualResult = UserValidator.IsNameValid(name);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}