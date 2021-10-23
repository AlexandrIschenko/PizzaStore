using System.Collections.Generic;

namespace PizzaStore.Models
{
    public class Pizza
    {
        public double Price { get; set; }
        public string Name { get; set; }
        public PizzaType Type { get; set; }
        public bool IsBaked { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();
    }
}