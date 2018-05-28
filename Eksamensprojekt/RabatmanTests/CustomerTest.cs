using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.BaseTypes;
using DataAccessLayer.DataHandlers;
using DataAccessLayer;
using System.Collections.ObjectModel;

namespace RabatmanTests
{
    [TestClass]
    public class CustomerTest
    {
        public ObservableCollection<IBaseCustomer> Customers { get; set; }

        [TestMethod]
        public void AddCustomerTest()
        {
            //Arrange
            IPersistentCustomerDataHandler fakeHandler = new FakeCustomerDataHandler();
            IBaseCustomer newTestCustomer = new Customer
            {
                CustomerName = "Mig"
            };

            //Act
            Customers = fakeHandler.GetAllCustomers();
            int noOfCustomers = Customers.Count;
            Customers.Add(newTestCustomer);

            //Assert
            Assert.AreEqual(noOfCustomers+1, Customers.Count);
        }
    }
}
