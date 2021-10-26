using System;
using PizzaStore.Models;
using PizzaStore.Services;
using PizzaStore.Validators;


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
            Console.WriteLine($"Choose any pizza: (1){PizzaType.Neapolitan}(10$) , (2){PizzaType.Detroit}(12$), (3){PizzaType.California} (20$)");
            bool check;
            var pizzaType = "1";
            while (true)
            {
                string mathOperator = Console.ReadLine();
                pizzaType = mathOperator;
                    check = InputValidation.UserChosePizza(mathOperator);
                if (!check) Console.WriteLine("False input!Try again!");
                else break;
            }
            int intPizzaType = Convert.ToInt32(pizzaType) - 1;
            pizzaType = intPizzaType.ToString();

            var pizza = _pizzaService.ChoosePizza(pizzaType);

            _pizzaService.PayForPizza(_user, out bool checkPrice);
            if (checkPrice)
            {
                var createdPizza = _pizzaService.CreatePizza(pizza);

                Console.WriteLine($"{_user.Name}, please, take your {createdPizza.Name} pizza.");
            }
            else Console.WriteLine("Bye");
        }

    }
}