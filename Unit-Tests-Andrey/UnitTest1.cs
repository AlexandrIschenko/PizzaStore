using NUnit.Framework;
using PizzaStore;
using PizzaStore.Services;
using PizzaStore.Validators;
using PizzaStore.Models;
using System;

namespace Unit_Tests_Andrey
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Andrey", 2, "Andrey", 2)]
        [TestCase("valera01", 1, "valera01", 1)]
        [TestCase("Andrey", 0, "Andrey", 0)]
        [TestCase("007", 1, "007", 1)]
        //[TestCase("007", 1, "1007", 1)]

        public void CreateUserTest(string name, double amount, string nameExpected, double amountExpected)
        {
            var userActual = new UserService(new UserValidator()).CreateUser(name, amount);
            Assert.AreEqual(nameExpected, userActual.Name);
            Assert.AreEqual(amountExpected, userActual.Amount);
        }

        [TestCase("!#$", 2, "!#$ is invalid.")]
        [TestCase("Boris", 2, "Boris is invalid.")]
        [TestCase("Boris!", 2, "   is invalid.")]
        [TestCase("Boris", -1, "-1 is invalid.")]

        public void CreateUserCatchArgumentErrorsTest(string name, double amount, string errorExpected)
        {

            Assert.Throws<ArgumentException>( delegate { var userActual = new UserService(new UserValidator()).CreateUser(name, amount); }, errorExpected);

            //try
            //{
            //    var userActual = new UserService(new UserValidator()).CreateUser(name, amount);
            //}
            //catch (Exception ex)
            //{
            //    //Assert.Throws(ex, errorExpected);
            //    Assert.AreEqual(errorExpected, ex.Message.ToString());               
            //}            
        }
    }
}