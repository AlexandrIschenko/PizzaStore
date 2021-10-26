using System;
using NUnit.Framework;
using PizzaStore.Models;
using PizzaStore.Services;
using PizzaStore.Validators;

namespace PizzaStoreTests
{
    public class UserServiceUnitTest
    {      
        [TestCase("Vasya", 456, "Vasya", 456)]       
        [TestCase("Vasya", 0, "Vasya", 0)]
        [TestCase("123", 9980, "123", 9980)]
        public void PositiveCreateUserTest(string name, double balance, string expName, double expBalance)
        {
            // Arrange
            UserValidator uValidator = new UserValidator();
            UserService UService = new UserService(uValidator);
            User expResUser = new User(expName, expBalance);
            // Act
            User actResUser = UService.CreateUser(name, balance);
            // Assert
            Assert.AreEqual(expResUser.Name, actResUser.Name);
            Assert.AreEqual(expResUser.Balance, actResUser.Balance);
        }

        [TestCase("Olga", -90)]
        [TestCase("", 7657)]
        public void NegativeCreateUserTest(string name, double balance)
        {
            // Arrange
            UserValidator uValidator = new UserValidator();
            UserService UService = new UserService(uValidator);
            // Act
            // Assert
            Assert.Throws<ArgumentException>(delegate { UService.CreateUser(name, balance); });
        }
    }
}
