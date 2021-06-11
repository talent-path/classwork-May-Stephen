using System;
using VirtualVendingMachine.Models;

namespace VirtualVendingMachine.Daos
{
    public interface IVendingMachineDao
    {
        public VendingMachine VendingMachine { get; }

        public string ReadFile { get; set; }

        public void WriteToFile();

        public void RemoveSnack(Snack snack);
    }
}
