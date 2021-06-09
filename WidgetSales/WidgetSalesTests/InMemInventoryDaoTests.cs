using System;
using NUnit.Framework;
using WidgetSales;
using System.Linq;

namespace WidgetSalesTests
{
    public class InMemInventoryDaoTests
    {
        InMemInventoryDao _toTest;
        WidgetInventory toAdd;

        [SetUp]
        public void Setup()
        {
            _toTest = new InMemInventoryDao();
            toAdd = new WidgetInventory
            {
                Category = "test",
                Name = "test1",
                StockCount = 1
            };
        }

        [TestCase( "lumber", 1, "building supplies", 1)]
        [TestCase(null, null, null, 1)]
        //[TestCase("lumber", 1, "building supplies", 1)]
        //[TestCase("lumber", 1, "building supplies", 1)]
        //[TestCase("lumber", 1, "building supplies", 1)]
        public void TestAddWidgetInventory(string name, int qty, string cat, int expectedId )
        {
            WidgetInventory toAdd = new WidgetInventory {
                Category = cat,
                Name = name,
                StockCount = qty };
            int addedId = _toTest.Add(toAdd);

            WidgetInventory savedWidget = _toTest.GetByName(name);


            Assert.AreEqual(expectedId, addedId);
            Assert.AreEqual(savedWidget.Name, name);
            Assert.AreEqual(savedWidget.Category, cat);
            Assert.AreEqual(savedWidget.Id, expectedId);
            Assert.AreEqual(savedWidget.StockCount, qty);
        }

        [Test]
        public void ShouldNotBeAbleToChangeAddedWidget()
        {

            _toTest.Add(toAdd);

            toAdd.Name = "x";

            var storedWidget = _toTest.GetByName("test1");
            Assert.AreEqual("test1", storedWidget.Name);
        }

        [Test]
        public void NullAdd()
        {
            Assert.Throws<ArgumentNullException>(() => _toTest.Add(null));
        }

        [Test]
        public void TestGetByName()
        {
            _toTest.Add(toAdd);

            Assert.AreEqual("test1", _toTest.GetByName("test1").Name);

        }

        [Test]
        public void TestGetByNameNotFound()
        {
            _toTest.Add(toAdd);

            Assert.Throws<ItemNotFoundException>(() => _toTest.GetByName("badName"));
        }

        [TestCase("test1")]
        [TestCase("test2")]
        public void TestRemoveWidgetInventory(string name)
        {
            WidgetInventory toRemove = new WidgetInventory
            {
                Category = "test",
                Name = "test2",
                StockCount = 1
            };
            _toTest.Add(toAdd);
            _toTest.Add(toRemove);
            
            _toTest.RemoveWidgetByName(toRemove.Name);

            Assert.AreEqual(1, _toTest.CountWidgets());
        }

        [TestCase(1, "test", "test2", 1)]
        [TestCase(1, null, null, null)]
        public void TestEditWidget(int id, string cat, string name, int stock)
        {
            _toTest.Add(toAdd);
            WidgetInventory toEdit = new WidgetInventory
            {
                Id = id,
                Category = cat,
                Name = name,
                StockCount = stock
            };

            _toTest.EditWidget(toEdit);

            Assert.AreEqual(name, _toTest.GetByName(name).Name);

        }


    }
}