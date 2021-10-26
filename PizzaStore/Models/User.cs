namespace PizzaStore.Models
{
    public class User
    {
        public string Name { get; }
        public double Balance { get; set; }

        public User(string name, double balance)
        {
            Name = name;
            Balance = balance;
        }
    }
}