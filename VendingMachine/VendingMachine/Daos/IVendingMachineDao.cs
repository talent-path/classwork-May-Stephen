using System;
using System.Collections.Generic;
using VirtualVendingMachine.Models;

namespace VirtualVendingMachine.Daos
{
    public interface IVendingMachineDao
    {

        List<Snack> GetInventory();

        public void EditSnack(Snack snack);
    }
}
