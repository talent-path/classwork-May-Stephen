using System;
namespace VirtualVendingMachine.Models
{
    public class Snack : ISnack
    {
        public Snack(string name, decimal price, int qty)
        {
            Name = name;
            Price = price;
            Quantity = qty;
        }

        public string Name { get;  }
        public decimal Price { get; }
        public int Quantity { get; }
    }
}
