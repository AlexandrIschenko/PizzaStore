using NUnit.Framework;
using System;
using PizzaStore.Services;
using PizzaStore.Validators;


namespace KetTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Neapolitan", "Neapolitan")]
        [TestCase("Detroit", "Detroit")]
        [TestCase("California", "California")]
        public void PizzaType(string Namepizza, string pizzaTypeExpextedResult)
        {
            var pizzaResult = new PizzaService(new PizzaValidator()).ChoosePizza(Namepizza);
            Assert.AreEqual(pizzaTypeExpextedResult, pizzaTypeExpextedResult.Name);
         }
    }
}