using System;
using System.Collections.Generic;

namespace VirtualVendingMachine.Models
{
    public class VendingMachine : IVendingMachine
    {
        
        public List<Snack> Snacks { get; set; }

        public VendingMachine(List<Snack> snacks)
        {
            Snacks = snacks;
        }

        public VendingMachine(VendingMachine machine)
        {
            Snacks = new List<Snack>();

            foreach(Snack s in machine.Snacks)
            {
                Snacks.Add(s);
            }
        }

        
    }
}
