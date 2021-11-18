﻿using System;
using PizzaStore.Models;
using PizzaStore.Services;

namespace PizzaStore
{
    public class Menu
    {
        private readonly PizzaService _pizzaService;
        private readonly User _user;

        public Menu(PizzaService pizzaService, User user)
        {
            _pizzaService = pizzaService;
            _user = user;
        }

        public void MakeOrder()
        {
            Console.WriteLine($"Choose any pizza: (1){PizzaType.California} ({PricePolicy.PriceCalifornia}$) , (2){PizzaType.Detroit}({PricePolicy.PriceDetroit}$), (3){PizzaType.Neapolitan}({PricePolicy.PriceNeapolitan}$)");
            var pizzaType = Console.ReadLine();

            var pizza = _pizzaService.ChoosePizza(pizzaType);
            _pizzaService.PayForPizza(_user);
            var createdPizza = _pizzaService.CreatePizza(pizza);

            Console.WriteLine($"{_user.Name}, please, take your {createdPizza.Name} pizza.");
        }
    }
}