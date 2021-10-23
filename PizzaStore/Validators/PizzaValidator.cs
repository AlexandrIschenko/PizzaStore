using System;

namespace PizzaStore.Validators
{
    public class PizzaValidator
    {
        public bool IsPizzaTypeValid(string pizza, out PizzaType pizzaType)
        {
            var result = Enum.TryParse(pizza, out PizzaType pizzaT);
            pizzaType = pizzaT;

            return result;
        }
    }
}