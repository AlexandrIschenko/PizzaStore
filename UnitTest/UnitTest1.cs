using NUnit.Framework;
using PizzaStore;
using System.Collections.Generic;
using PizzaStore.Services;
using PizzaStore.Validators;
using PizzaStore.Models;
using System;


namespace PizzaStore.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //Services/PizzaIngridiendsServices:
        [Test]
        public void TestGetIngredientsByPizzaType()
        {
            var expResult = new List<string> { "Flour", "Mozzarella", "Tomato", "Tomato sauce", "Basil", "Yeast", "Olive oil" };
            var actualResult = PizzaIngredientsService.GetIngredientsByPizzaType(PizzaType.Neapolitan);
            Assert.AreEqual(expResult, actualResult);
        }

        //InputValidation:
        [TestCase("0",0)]
        [TestCase("asasa", double.MinValue)]
        [TestCase("10", 10)]
        [TestCase("-10", -10)]
        [TestCase("-0", 0)]

        public void TestReturnDouble(string num,double expResult)
        {           
            var actualResult =InputValidation.ReturnDouble(num);
            Assert.AreEqual(expResult, actualResult);
        }


        [TestCase("1", true)]
        [TestCase("4",false)]
        [TestCase("0", false)]
        public void TestUserChosePizza(string num, bool expResult)
        {
            var actualResult = InputValidation.UserChosePizza(num);
            Assert.AreEqual(expResult, actualResult);
        }

        //Validation:
        [TestCase(1, true)]
        [TestCase(-4, false)]
        [TestCase(0, true)]
        public void TestIsAmountValid(double num, bool expResult)
        {
            var userValidator = new UserValidator();
            var actualResult = userValidator.IsAmountValid(num);
            Assert.AreEqual(expResult, actualResult);
        }


        [TestCase("Di", true)]
        [TestCase("$%@", false)]
        [TestCase("0 e", true)]
        public void TestIsNameValid(string num, bool expResult)
        {
            var userValidator = new UserValidator();
            var actualResult = userValidator.IsNameValid(num);
            Assert.AreEqual(expResult, actualResult);
        }

        [TestCase("Neapolitan", true)]

        public void TestIsPizzaTypeValid(string num, bool expResult)
        {
            var pizzaValidator = new PizzaValidator();
            var actualResult = pizzaValidator.IsPizzaTypeValid(num,out PizzaType pizzaType);
            Assert.AreEqual(expResult, actualResult);
        }

        [TestCase("Di",100,"Di",100)]
        [TestCase("someone",0, "someone", 0)]
        [TestCase("Di0", 10, "Di0", 10)]

        public void TestCreateUser(string name, double amount, string expName, double expAmount)
        {
            var actualResult = new UserService(new UserValidator()).CreateUser(name, amount);
            Assert.AreEqual(expName, actualResult.Name);
            Assert.AreEqual(expAmount, actualResult.Amount);

        }


        //Что тут не так?
        [TestCase("2", "California", 20)]
        [TestCase("1", "Detroit", 12)]
        [TestCase("0", "Neapolitan", 10)]
        public void TestChoosePizza(string numOfPizza, string nameExpPizza, double pricePizza)
        {
            PizzaService pizzaService = new PizzaService(new PizzaValidator());
            Assert.AreEqual(nameExpPizza, pizzaService.ChoosePizza(numOfPizza).Name);
            Assert.AreEqual(pricePizza, pizzaService.ChoosePizza(numOfPizza).Price);

        }


        [TestCase("0", "Di", 10, 0)] 
        [TestCase("1", "DiO", 20, 8)]
        public void TestPayForPizza(string numOfPizza, string nameUser, double amountUser, double expAmount)
        {
            var pizzaService = new PizzaService(new PizzaValidator());
            pizzaService.ChoosePizza(numOfPizza);
            User user = new UserService(new UserValidator()).CreateUser(nameUser, amountUser);
            Assert.AreEqual(expAmount, pizzaService.PayForPizza(user,out bool check).Amount);
        }



    }
}