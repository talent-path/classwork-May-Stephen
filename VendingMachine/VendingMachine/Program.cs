﻿using System;
using VirtualVendingMachine.Daos;
using VirtualVendingMachine.Services;
using VirtualVendingMachine.Views;

namespace VirtualVendingMachine
{
    class Program
    {

        // REQUIREMENTS
        /* 
        When the application starts, the user should be presented with a list of candies and prices. (DONE)

        Users should be able to "enter money" (just type in how much they want to enter). (DONE)

        Users should be able to buy items if they've entered enough money (DONE)

        Users should not be able to buy items if they have not entered enough money 

        When a user buys an item, it should reduce the quantity stored by one
        and "return" change (display the money to the user)
        showing dollars, quarters, dimes, nickles, and pennies (a Change class may help here)

        Users should not be able to buy items that are out of stock.

        The system should have a FileDAO for offline persistence to track candy quantities and prices from the machine.

        The service layer should be testable using an InMemoryDao, however.

        Unit testing the FileDAO will mean reseting the TESTING item file
        (this is most easily accomplished by deleting it and copying)
        a second file such that the copy has the name items.txt)
        */

        static void Main(string[] args)
        {
            VendingMachineController controller = new VendingMachineController(
                new VendingMachineService(new VendingMachineFileDao()),
                new VendingMachineView());

            controller.StartMachine();
        }
    }
}
