using NUnit.Framework;
using PizzaStore;
using PizzaStore.Services;
using PizzaStore.Validators;
using PizzaStore.Models;
using System;
using System.Collections.Generic;

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

        public void CreateUserTest(string name, double amount, string nameExpected, double amountExpected)
        {
            var userActual = new UserService(new UserValidator()).CreateUser(name, amount);
            Assert.AreEqual(nameExpected, userActual.Name);
            Assert.AreEqual(amountExpected, userActual.Amount);
        }

        [TestCase("!#$", 2, "!#$ is invalid.")]
        [TestCase("Boris!", 2, "Boris! is invalid.")]
        [TestCase("Boris", -1, "-1 is invalid.")]

        public void CreateUserCatchArgumentErrorsTest(string name, double amount, string errorExpected)
        {
            Assert.Throws<ArgumentException>( delegate { var userActual = new UserService(new UserValidator()).CreateUser(name, amount); }, errorExpected);        
        }

        [TestCase("Andrey", true)]
        [TestCase("valera01", true)]
        [TestCase("#$%", false)]
        [TestCase("Bor!s", false)]

        public void UserValidatorNameTest(string name, bool expectedResult)
        {
            var validatorActual = new UserValidator();
            bool actualResult = validatorActual.IsNameValid(name);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("1", true)]
        [TestCase("0", false)]
        [TestCase("-1", false)]

        public void UserValidatorAmountTest(double amount, bool expectedResult)
        {
            var validatorActual = new UserValidator();
            bool actualResult = validatorActual.IsAmountValid(amount);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("3", true)]
        [TestCase("2", true)]
        [TestCase("1", true)]
        [TestCase("0", false)]
        [TestCase("-1", false)]
        [TestCase("4", false)]

        public void IsPizzaTypeValidTest(string pizzaNumber, bool expectedResult)
        {
            PizzaValidator pizzaValidator = new PizzaValidator();
            bool actualResult = pizzaValidator.IsPizzaTypeValid(pizzaNumber, out PizzaType pizzaType);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("1", "California", 8)]
        [TestCase("2", "Detroit", 10)]
        [TestCase("3", "Neapolitan" , 12)]

        public void ChoosePizzaTest(string pizzaNumber, string pizzaNameExpected, double pizzaPrice)
        {
            PizzaService pizzaService = new PizzaService(new PizzaValidator());
            Assert.AreEqual(pizzaNameExpected, pizzaService.ChoosePizza(pizzaNumber).Name);
            Assert.AreEqual(pizzaPrice, pizzaService.ChoosePizza(pizzaNumber).Price);
        }

        [TestCase("abc", "cba does not exist. Please choose another.")]
        [TestCase("!@#", "!@# does not exist. Please choose another.")]
        [TestCase("  ", "   does not exist. Please choose another.")]

        public void ChoosePizzaExceptionTest(string pizzaNumber, string expectedExceptionText)
        {
            PizzaService pizzaService = new PizzaService(new PizzaValidator());
            Assert.Throws<ArgumentException>(delegate { pizzaService.ChoosePizza(pizzaNumber); }, expectedExceptionText);
        }

        [TestCase("1", "Andrey", 1, -8)] // take pizza number 1, amount 1 -  pizza price 8x1 = -8
        [TestCase("2", "Ket", 2, -20)] // take pizza number 2, amount 2 -  pizza price 10x2 = -20

        public void PayForPizzaTest(string pizzaNumber, string userName, double pizzaAmount, double expectedAmountLeft)
        {
            PizzaService pizzaService = new PizzaService(new PizzaValidator());
            pizzaService.ChoosePizza(pizzaNumber);
            User user = new UserService(new UserValidator()).CreateUser(userName, pizzaAmount);
            Assert.AreEqual(expectedAmountLeft, pizzaService.PayForPizza(user).Amount);
        }

        [TestCase("1", true)]
        [TestCase("2", true)]
        //[TestCase("2", false)]

        public void CreatePizzaTest(string pizzaNumber, bool expectedResult)
        {
            PizzaService pizzaService = new PizzaService(new PizzaValidator());
            var pizza = pizzaService.ChoosePizza(pizzaNumber);
            Assert.AreEqual(expectedResult, pizzaService.CreatePizza(pizza).IsBaked);
        }

        [TestCase("2", "White sugar", "Olive oil", "Bread flour", "Kosher salt", "Red onion", "Garlic", "Mushrooms")]
        [TestCase("1", "Honey", "Olive oil", "Flour", "Salt", "Red onion", "Black olives", "Mushrooms")]
        [TestCase("3", "Flour", "Mozzarella", "Tomato", "Tomato sauce", "Basil", "Yeast", "Olive oil")]

        public void GetIngredientsByPizzaType(string pizzaNumber, params string[] ingridients)
        {
            List<string> ingridientsList = new List<string>();
            foreach (var item in ingridients)
            {
                ingridientsList.Add(item);
            }
            
            PizzaService pizzaService = new PizzaService(new PizzaValidator());
            var pizza = pizzaService.ChoosePizza(pizzaNumber);
            Assert.AreEqual(ingridientsList, PizzaIngredientsService.GetIngredientsByPizzaType(pizzaService.CreatePizza(pizza).Type));
        }
    }
}