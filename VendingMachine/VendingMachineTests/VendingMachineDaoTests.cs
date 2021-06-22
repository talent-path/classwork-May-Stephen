using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using VirtualVendingMachine.Daos;
using VirtualVendingMachine.Models;

namespace VendingMachineTests
{
    public class VendingMachineDaoTests
    {
        public VendingMachineDaoTests()
        {
        }

        private IVendingMachineDao _dao;

        private static readonly string test = "../../../../Test.txt";

        private static readonly string seed = "../../../../Seed.txt";



        [OneTimeSetUp]
        public void InitialSetUp()
        {
            _dao = new VendingMachineFileDao(test);
        }

        [SetUp]
        public void SetUp()
        {
            File.Delete(test);
            File.Copy(seed, test);
        }


            //Doritos, 0.75, 15
            //Snickers, 1.00, 12
            //Bubble Gum, 0.50, 4
            //Reese's, 0.75, 11
            //Rice Krispy Treat, 1.25, 7
        [Test]
        public void GetAllSnacksTest()
        {
            List<Snack> snacks = _dao.GetInventory();
            Snack s = new Snack("Doritos", 0.75M, 15);
            Assert.AreEqual(s, snacks[0]);
            //Assert.AreEqual(new Snack("Snickers",1.00M,12), snacks[1]);
            //Assert.AreEqual(new Snack("Bubble Gum",0.50M,4), snacks[2]);
            //Assert.AreEqual(new Snack("Reese's",0.75M,11), snacks[3]);
            //Assert.AreEqual(new Snack("Rice Krispy Treat",1.25M,7), snacks[4]);
            Assert.AreEqual(snacks.Count, 5);
        }

        //[TestCase("Doritos", 0, 14)]
        //[TestCase("Snickers", 1, 11)]
        //[TestCase("Bubble Gum", 2, 3)]
        //[TestCase("Reese's", 3, 10)]
        //[TestCase("Rice Krispy Treat", 4, 6)]
        //public void RemoveSnackTest(string name, int index, int qty)
        //{
        //    List<Snack> snacks = _dao.GetInventory();
        //    _dao.EditSnack(snacks[index]);
        //    Assert.AreEqual(qty, _dao.GetInventory()[index].Quantity);
        //}

        //[TestCase("Not a snack")]
        //[TestCase(null)]
        //public void DoNotRemoveInvalidSnack(Snack snack) 
        //{
        //    List<Snack> allSnacks = _dao.GetInventory();
        //    _dao.EditSnack(snack);
        //    List<Snack> snacksAfterRemove = _dao.GetInventory();
        //    Assert.AreEqual(allSnacks.Count, snacksAfterRemove.Count);

        //}
    }
}
