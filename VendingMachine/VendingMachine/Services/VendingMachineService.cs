using System;
using System.Collections.Generic;
using VirtualVendingMachine.Models;
using VirtualVendingMachine.Daos;


namespace VirtualVendingMachine.Services
{
    public class VendingMachineService : IVendingMachineService
    {

        private IVendingMachineDao _vendingMachineDao;

        public VendingMachineService(IVendingMachineDao dao)
        {
            _vendingMachineDao = dao;
        }

        public int ChooseSnack(List<Snack> snacks, decimal userMoney)
        {


            Console.WriteLine("Select the number for the product you would like to buy: ");
            int choice = int.Parse(Console.ReadLine());


            if (choice > 0 && choice < snacks.Count)
            {
                Console.WriteLine("You chose item number " + choice);
                BuySnack(snacks[choice - 1], userMoney);

            }
            else
            {
                Console.WriteLine("Invalid choice. Please choose a product that is available.");
            }


            return choice;

        }

        public List<Snack> GetInventory()
        {
            return _vendingMachineDao.GetInventory();

        }

        public decimal BuySnack(Snack snack, decimal money)
        {
            if (snack.Quantity < 1)
            {
                //TODO create out of stock exception 
                Console.WriteLine("Out of stock");
            }

            if (money < snack.Price)
            {
                //TODO create insufficient funds exception
                Console.WriteLine("Not enough money provided.");
            }

            _vendingMachineDao.EditSnack(snack);

            Console.WriteLine($"You have ${money - snack.Price} remaining.");
            return money - snack.Price;


        }

        // TODO Move the remove quantity functionality here


    }
}
