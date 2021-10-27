using NUnit.Framework;
using PizzaStore;
using PizzaStore.Services;
using PizzaStore.Validators;
using System;

namespace UnitTests
{
    public class Tests
    {

        [Test]
        public void TestChoosePizza()
        {
            PizzaService srv = new PizzaService(new PizzaValidator());

            Assert.Throws<ArgumentException>(() => srv.ChoosePizza("pizza"));
        }

        [TestCase("1", true)]
        [TestCase("2", true)]
        [TestCase("3", true)]
        public void ChooseTypeOfPizzaTest(string pizzaNumber, bool expectedResult)
        {
            PizzaValidator ChooseTypeOfPizza = new PizzaValidator();
            bool actualResult = ChooseTypeOfPizza.IsPizzaTypeValid(pizzaNumber, out PizzaType pizzaType);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("Neapolitan", "California")]
        [TestCase("California", "Neapolitan")]
        [TestCase("California", "California")]
        public void CorrectPizzaTypeTest(string namePizza, string expectedResult)
        {
            var pizzaResult = new PizzaService(new PizzaValidator()).ChoosePizza(namePizza);
            Assert.AreEqual(expectedResult, pizzaResult.Name);
        }
    }
}