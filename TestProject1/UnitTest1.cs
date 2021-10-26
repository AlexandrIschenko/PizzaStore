using NUnit.Framework;
using PizzaStore;
using PizzaStore.Services;
using PizzaStore.Validators;
using PizzaStore.Models;
using System;

namespace TestUnit1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        [TestCase("345", "345", 3)]
        [TestCase("Kostya", "Kostya", 2)]
        [TestCase("Kosti4ka", "Kosti4ka", 1)]
        [TestCase("gall", "gall", 0)]


        public void NameArgumTest(string name, string nameExpected, double amountExpected)
        {
            var userActual = new UserService(new UserValidator()).CreateUser(name, amountExpected);
            Assert.AreEqual(nameExpected, userActual.Name);
        }

        [TestCase(" ", 0, "is invalid")]
        [TestCase(" ", 1, "is invalid")]
        [TestCase("Foma", 2, "invalid")]
        [TestCase("Kosti4ka", 5, "Kosti4ka")]
        public void NegativeUserCheck(string name, double amount, string invalidExpectedResult)
        {
            try
            {
                var userNew = new UserService(new UserValidator()).CreateUser(name, amount);
            }
            catch (Exception expection)
            {
                Assert.AreEqual(invalidExpectedResult, expection.Message.ToString());
            }
        }
    }
}