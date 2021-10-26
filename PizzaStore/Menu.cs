using System;
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
            var pizzaType = " ";
            while (pizzaType == " ")
            {
                Console.WriteLine($"Choose any pizza: (1){PizzaType.California} (8$) ," +
                    $" (2){PizzaType.Detroit}(10$), " +
                    $"(3){PizzaType.Neapolitan}(12$) and press \"Enter\"");
                pizzaType = Console.ReadLine().Trim();
                foreach (char x in pizzaType)
                {
                    if (!char.IsLetter(x))
                    {
                        pizzaType = " ";
                        Console.WriteLine("Wrong choise. Try again.");
                        break;
                    }
                }
                if (pizzaType.Length == 0)
                {
                    pizzaType = " ";
                    Console.WriteLine("The string is empty.");
                    continue;
                }
            }

            var pizza = _pizzaService.ChoosePizza(pizzaType);
            _pizzaService.PayForPizza(_user);
            var createdPizza = _pizzaService.CreatePizza(pizza);

            Console.WriteLine($"{_user.Name}, please, take your {createdPizza.Name} pizza.");
        }
    }
}