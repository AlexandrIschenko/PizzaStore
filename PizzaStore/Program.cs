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

            Console.WriteLine("Hello, please input your balance:");
            var balance = double.Parse(Console.ReadLine());

            var user = new UserService(new UserValidator()).CreateUser(name, balance);
            var pizzaService = new PizzaService(new PizzaValidator());
            var menu = new Menu(pizzaService, user);

            menu.MakeOrder();
            Console.WriteLine("Come back again!");
            Console.ReadLine();
        }
    }
}