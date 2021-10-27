using NUnit.Framework;
using PizzaStore;
using PizzaStore.Validators;

namespace PizzaStore.UnitTests
{
    public class Tests
    {
        [TestCase("K0lObok9 puPkin", true)]
        public void IsNameValidPositiveTest(string testName, bool expectedResult)
        {
            UserValidator uv = new UserValidator();
            bool actualResult = uv.IsNameValid(testName);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(" Kolya12", false)]
        [TestCase("inokentii!", false)]
        [TestCase("*", false)]
        [TestCase("", false)]
        public void IsNameValidNegativeTest(string testName, bool expectedResult)
        {
            UserValidator uv = new UserValidator();
            bool actualResult = uv.IsNameValid(testName);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}