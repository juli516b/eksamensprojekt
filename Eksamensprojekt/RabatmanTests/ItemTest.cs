using System;
using Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RabatmanItemTest
{
    [TestClass]
    public class ItemTest
    {
        [TestMethod]
        public void AddItemToRepository()
        {
            //Arrange
            IPersistentDataHandler fakeItemDataHandler = new FakeItemDataHandler();
            ItemRepository ir = ItemRepository.GetInstance(fakeItemDataHandler);
            IBaseItem item = new Item("PommesDeluxe","12345678",25.95);
            IBaseItem item2 = new Item("PommesDeluxe2", "123456782", 252.95);
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
