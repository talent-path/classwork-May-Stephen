using System;
namespace VirtualVendingMachine.Models
{
    public interface ISnack
    {
        public string Name { get; }
        public decimal Price { get; }
        public int Quantity { get; }
    }
}
