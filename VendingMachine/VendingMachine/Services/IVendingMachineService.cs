using System;
using System.Collections.Generic;
using VirtualVendingMachine.Models;

namespace VirtualVendingMachine
{
    public interface IVendingMachineService
    {
        public List<Snack> GetInventory();
     
        public decimal BuySnack(Snack snack, decimal money);

        public int ChooseSnack(List<Snack> snacks, decimal userMoney);
    }
}
