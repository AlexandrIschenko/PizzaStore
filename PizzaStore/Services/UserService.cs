using System;
using PizzaStore.Models;
using PizzaStore.Validators;

namespace PizzaStore.Services
{
    public class UserService
    {
        private readonly UserValidator _userValidator;

        public UserService(UserValidator userValidator)
        {
            _userValidator = userValidator;
        }

        public User CreateUser(string name, double amount)
        {
            if (!_userValidator.IsNameValid(name))
                throw new ArgumentException($"{name} is invalid.");

            if (!_userValidator.IsAmountValid(amount))
                throw new ArgumentException($"{amount} is invalid.");

            var user = new User(name, amount);

            return user;
        }
    }
}