using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VirtualVendingMachine.Models;

namespace VirtualVendingMachine.Daos
{
    public class VendingMachineInMemDao : IVendingMachineDao
    {
        private List<Snack> _snacks = new List<Snack>();

        public VendingMachineInMemDao()
        {
            _snacks.Add(new Snack("Doritos", 0.75M, 15));
            _snacks.Add(new Snack("Snickers", 1.00M, 12));
            _snacks.Add(new Snack("Bubble Gum", 0.50M, 4));
            _snacks.Add(new Snack("Reese's", 0.75M, 11));
            _snacks.Add(new Snack("Rice Krispy Treat", 1.25M, 7));

        }

        public List<Snack> GetInventory()
        {
            return _snacks.Select(s => new Snack(s)).ToList();
        }

        public void EditSnack(Snack snack)
        {
            _snacks = GetInventory().Select(s =>
            s.Name == snack.Name ?
            new Snack(s.Name, s.Price, s.Quantity - 1) : s).ToList();
        }

       
    }
}
