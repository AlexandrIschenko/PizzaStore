using NUnit.Framework;
using PizzaStore;
using PizzaStore.Services;
using PizzaStore.Validators;
using PizzaStore.Models;
using System;

namespace TestProject3
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Vika", 2, 2)]
        [TestCase("Tina23", 1, 1)]
        [TestCase("05simba", 3, 3)]
        public void AmountTest(string name, double amount, double resultExpected)
        {
            var userNew = new UserService(new UserValidator()).CreateUser(name, amount);
            Assert.AreEqual(resultExpected, userNew.Amount);
        }

        [TestCase("Vika", 1, "Vika")]
        [TestCase("Tina23", 1, "Tina23")]
        [TestCase("05simba", 1, "05simba")]
        public void UserNameTest(string name, double amountExpected, string resultExpected)
        {
            var userNew = new UserService(new UserValidator()).CreateUser(name, amountExpected);
            Assert.AreEqual(resultExpected, userNew.Name);
        }

        [TestCase(" ", 2, " invalid")]
        [TestCase("Ira", 2, "ira - invalid")]
        public void UserErrorsTest(string name, double amount, string errorExpectedResult)
        {
            try
            {
                var userNew = new UserService(new UserValidator()).CreateUser(name, amount);
            }
            catch (Exception expection)
            {
               Assert.AreEqual(errorExpectedResult, expection.Message.ToString());
            }
        }

        [TestCase("Neapolitan", "Neapolitan")]
        [TestCase("California", "California")]
        public void PizzaTypeTest(string Namepizza, string pizzaTypeExpectedResult)
        {
            var pizzaResult = new PizzaService( new PizzaValidator()).ChoosePizza(Namepizza);
            Assert.AreEqual(pizzaTypeExpectedResult, pizzaResult.Name);
        }
    }
}