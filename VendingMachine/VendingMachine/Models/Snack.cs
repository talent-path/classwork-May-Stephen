using System;
namespace VirtualVendingMachine.Models
{
    public class Snack : ISnack
    {

        public string Name { get; }
        public decimal Price { get; }
        public int Quantity { get; set; }

        public Snack(string name, decimal price, int qty)
        {
            Name = name;
            Price = price;
            Quantity = qty;
        }

        public Snack(Snack snack)
        {
            Name = snack.Name;
            Price = snack.Price;
            Quantity = snack.Quantity;
        }

        public Snack()
        {

        }

    }
}
