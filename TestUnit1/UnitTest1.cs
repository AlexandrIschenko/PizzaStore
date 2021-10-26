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
        [TestCase("gall", "gall" , 0)]
       

        public void NameArgumTest(string name, string nameExpected, double amountExpected)
        {
            var userActual = new UserService(new UserValidator()).CreateUser(name, amountExpected);
            Assert.AreEqual(nameExpected, userActual.Name);
        }
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}