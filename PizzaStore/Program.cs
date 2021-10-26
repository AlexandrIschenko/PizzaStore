using System;
using PizzaStore.Services;
using PizzaStore.Validators;

namespace PizzaStore
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Hello, please write your name:");
            var name = Console.ReadLine();

            Console.WriteLine("Hello, please write amount:");
            double amount;
            double checkAmount = double.MinValue;
            do
            {
                string num = Console.ReadLine();
                amount = InputValidation.ReturnDouble(num);
                if (amount == checkAmount|| amount<0) Console.WriteLine("False input.Try again!");
                else break;
            } while (true);
            var user = new UserService(new UserValidator()).CreateUser(name, amount);
            var pizzaService = new PizzaService(new PizzaValidator());
            var menu = new Menu(pizzaService, user);

            menu.MakeOrder();
        }
    }
}