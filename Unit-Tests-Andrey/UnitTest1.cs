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

        [TestCase("Andrey", 2, "Andrey")]
        [TestCase("valera01", 1, "valera01")]
        [TestCase("Andrey", 0, "Andrey")]
        [TestCase("007", 1, "007")]
        //[TestCase("007", 1, "1007")]

        public void CreateUserNameArgumentTest(string name, double amountExpected, string nameExpected)
        {        
            var userActual = new UserService(new UserValidator()).CreateUser(name, amountExpected);
            Assert.AreEqual(nameExpected, userActual.Name);
        }

        [TestCase("Andrey", 2, 2)]
        [TestCase("valera01", 1, 1)]
        [TestCase("Andrey", 0, 0)]
        [TestCase("007", 1, 1)]
        //[TestCase("007", 1, 2)]

        public void CreateUserAmountArgumentTest(string name, double amount, double amountExpected)
        {        
            var userActual = new UserService(new UserValidator()).CreateUser(name, amount);
            Assert.AreEqual(amountExpected, userActual.Amount);
        }

        [TestCase("Andrey ", 2, "Andrey  is invalid.")]
        [TestCase("!#$", 2, "!#$ is invalid.")]
        [TestCase("Boris", 2, "boris is invalid.")]
        //[TestCase("007", 1, "1007")]

        public void CreateUserCatchArgumentErrorsTest(string name, double amount, string errorExpected)
        {
            try
            {
                var userActual = new UserService(new UserValidator()).CreateUser(name, amount);
            }
            catch (Exception ex)
            {
                //Assert.Throws(ex, errorExpected);
                Assert.AreEqual(errorExpected, ex.Message.ToString());               
            }            
        }

        //[TestCase("Andrey", 2, "Andrey", 2)]
        //[TestCase("valera01", 1, "valera01", 1)]
        //[TestCase("Andrey", 0, "Andrey", 0)]
        //[TestCase("007", 1, "007", 1)]
        //[TestCase("007", 1, "007", 1)]

        //public void CreateUserTest(string name, double amount, string nameExpected, double amountExpected)
        //{
        //    var expectedResult = new User(nameExpected, amountExpected);
        //    var userActual = new UserService(new UserValidator()).CreateUser(name, amount);
        //    var actualResult = new User(userActual.Name, userActual.Amount);
        //    Assert.AreEqual(expectedResult, actualResult);
        //}
    }
}