using System;
using PizzaStore.Services;
using PizzaStore.Validators;

namespace PizzaStore
{
    internal static class Program
    {
        private static void Main()
        {
            bool check = false;
            Console.WriteLine("Hello, please write your name:");
            var name = Console.ReadLine();
            name = name.Trim(new char[] { ' ' });
            for (int i = 0; i < name.Length; i++)
            {
                if (name.ToLower()[i] >= 'a' && name[i] <= 'z' && name[i] != ' ')
                {
                    check = true;
                }
                else
                {
                    check = false;
                    break;
                }
            }
            while (name.Length < 2 || !check)
            {
                Console.WriteLine("\n Wrong input! Enter again your name and press \"Enter\":");
                name = Console.ReadLine();
                name = name.Trim(new char[] { ' ' });
                for (int i = 0; i < name.Length; i++)
                {
                    if (name.ToLower()[i] >= 'a' && name[i] <= 'z' && name[i] != ' ')
                    {
                        check = true;
                    }
                    else
                    {
                        check = false;
                        break;
                    }
                }
            }

            Console.WriteLine("Hello, please write amount:");
            bool isNum = double.TryParse(Console.ReadLine(), out var amount);
            while (!isNum || (amount < 1 || amount > 14))
            {
                Console.WriteLine("\n Wrong amount! Try again[please, used a numbers] and press \"Enter\":");
                isNum = double.TryParse(Console.ReadLine(), out amount);
            }

            var user = new UserService(new UserValidator()).CreateUser(name, amount);
            var pizzaService = new PizzaService(new PizzaValidator());
            var menu = new Menu(pizzaService, user);

            menu.MakeOrder();
        }
    }
}