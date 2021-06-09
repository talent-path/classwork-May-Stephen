using NUnit.Framework;
using LinkedList;
using System.Linq;
using System;

namespace LinkedListsTests
{
    
    public class Tests

        //Assemble
        //Ace
        //Asert
    {

        DavidLinkedList<string> list = new DavidLinkedList<string>();

        [OneTimeSetUp]
        public void SetUpAllTests()
        {
            
        }

        [OneTimeSetUp]
        public void SecondSetup()
        {

        }

        [SetUp]
        public void Setup()
        {
            list = new DavidLinkedList<string>();
        }


        // [Values] passes all of the values, tries each combo
        // (this one will produce 9 tests)

        [Test]
        public void LinkedListAddTest(
            [Values("one", "")]string first,
            [Values("two", "")]string second)
        {
            list.Add(first);
            
            Assert.AreEqual(first, list.First());
            Assert.AreEqual(1, list.Count());

            list.Add(second);
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(first, list.First());
            Assert.AreEqual(second, list.Skip(1).First());

            // test for third element

        }

        [TestCase("one","two")]
        [TestCase("", "")]
        public void LinkedListRemoveTest(string first, string second)
        {
            list.Add(first);

            Assert.AreEqual(first, list.First());
            Assert.AreEqual(1, list.Count());

            list.Add(second);

            list.Remove(first);
            Assert.AreEqual(second, list.First());
            Assert.AreEqual(1, list.Count());

        }

        [Test]
        public void LinkedListRemoveNotFoundTest()
        {
            
            list.Add("one");

            Assert.AreEqual("one", list.First());
            Assert.AreEqual(1, list.Count());

            list.Add("two");
            

            Assert.Throws<ItemNotFoundException>(() => list.Remove("three"));
        }

        [Test]
        public void LinkedListAddNullTest()
        {
            Assert.Throws<ArgumentNullException>(() => list.Add(null));
        }

        
    }
}
