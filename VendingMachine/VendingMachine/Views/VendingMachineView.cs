using System;
using System.Collections.Generic;
using VirtualVendingMachine.Models;

namespace VirtualVendingMachine.Views
{
    public class VendingMachineView
    {
        public VendingMachineView()
        {
        }

        public decimal GetUserMoney()
        {
            Console.WriteLine("How much money would you like to insert?");
            decimal money = decimal.Parse(Console.ReadLine());

            return money;
        }


        public void DisplayChoices(List<Snack> snacks)
        {
            foreach (Snack s in snacks)
            {
                int num = snacks.IndexOf(s) + 1;
                Console.WriteLine(num + ": " + s.Name + " -- " + s.Price + " -- " + s.Quantity);
            }

           
        }
    }
}
