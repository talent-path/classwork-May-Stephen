using System;
namespace VirtualVendingMachine
{
    public class VendingMachineController
    {

        private IVendingMachineService _service;

        public VendingMachineController(IVendingMachineService service) 
        {
            _service = service;
        }

        public void StartMachine()
        {
            while(true)
            {
                decimal totalMoney = _service.GetTotalMoney();
                _service.GetInventory();
                break;
            }
        }
    }
}
