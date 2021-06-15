using System;
using System.Collections.Generic;
using VirtualVendingMachine.Models;
using VirtualVendingMachine.Views;

namespace VirtualVendingMachine
{
    public class VendingMachineController
    {

        private IVendingMachineService _service;
        private VendingMachineView _view;

        public VendingMachineController(IVendingMachineService service, VendingMachineView view) 
        {
            _service = service;
            _view = view;
        }

        public void StartMachine()
        {

            decimal userMoney = _view.GetUserMoney();

            _view.DisplayChoices(_service.GetInventory());

            _service.ChooseSnack(_service.GetInventory(), userMoney);

            

        }

        
    }
}
