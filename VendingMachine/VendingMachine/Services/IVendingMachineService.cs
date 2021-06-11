using System;
using System.Collections.Generic;

namespace VirtualVendingMachine
{
    public interface IVendingMachineService
    {
        public List<string> GetInventory();
        public decimal GetTotalMoney();
        public void ShowInventory();
    }
}
