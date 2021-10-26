using NUnit.Framework;
using PizzaStore;
using PizzaStore.Services;
using PizzaStore.Validators;
using PizzaStore.Models;
using System;
using System.Collections.Generic;

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
        public void PizzaTypeTest(string namePizza, string pizzaTypeExpectedResult)
        {
            var pizzaResult = new PizzaService(new PizzaValidator()).ChoosePizza(namePizza);
            Assert.AreEqual(pizzaTypeExpectedResult, pizzaResult.Name);
        }

        [TestCase("zzz", "zzz Does not exist. Please choose another.")]
        [TestCase("***", "*** Does not exist. Please choose another.")]
        [TestCase("  ", "   Does not exist. Please choose another.")]
        public void PizzaErrorsTest(string pizzaNumber, string expectedExceptionText)
        {
            PizzaService pizzaService = new PizzaService(new PizzaValidator());
            Assert.Throws<ArgumentException>(delegate { pizzaService.ChoosePizza(pizzaNumber); }, expectedExceptionText);
        }

        [TestCase("1", true)]
        [TestCase("-1", false)]
        public void UserValidatorAmountTest(double amountUser, bool expectedResult)
        {
            var validatorActual = new UserValidator();
            bool actualResult = validatorActual.IsAmountValid(amountUser);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("1", true)]
        [TestCase("2", true)]
        [TestCase("3", true)]
        public void IsPizzaTypeValidTest(string pizzaNumber, bool expectedResult)
        {
            PizzaValidator pizzaValidator = new PizzaValidator();
            bool actualResult = pizzaValidator.IsPizzaTypeValid(pizzaNumber, out PizzaType pizzaType);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("1", true)]
        [TestCase("2", true)]
        public void CreatePizzaTest(string pizzaNumber, bool expectedResult)
        {
            PizzaService pizzaService = new PizzaService(new PizzaValidator());
            var pizza = pizzaService.ChoosePizza(pizzaNumber);
            Assert.AreEqual(expectedResult, pizzaService.CreatePizza(pizza).IsBaked);
        }
    } 
}