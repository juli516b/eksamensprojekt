using System;
using Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void AddItemToRepository()
        {
            //Arrange
            IPersistentDataHandler fakeItemDataHandler = new FakeItemDataHandler();
            ItemRepository ir = new ItemRepository(fakeItemDataHandler);
            IItem item = new Item("PommesDeluxe","12345678",25.95);
            IItem item2 = new Item("PommesDeluxe2", "123456782", 252.95);

            //Act
            ir.AddItem(item);
            //Assert
            Assert.AreEqual(1,ir.Items.Count);

            ir.AddItem(item2);
            Assert.AreEqual(2, ir.Items.Count);
            Assert.AreEqual(true, ir.Items.Contains(item));
        }
    }
}
