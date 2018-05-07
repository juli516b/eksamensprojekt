using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel;
using Model;

namespace RabatManCustomerTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void AddCustomerTest()
        {
            //Arrange
            
            IPersistentCustomerDataHandler fakeHandler = new FakeCustomerDataHandler();
            IBaseCustomer newTestCustomer = new Customer()
            {
                CustomerName = "Mig"
            };
            CustomerRepository testRepo = CustomerRepository.GetInstance(fakeHandler);
            int noOfCustomers = testRepo.Customers.Count;
            testRepo.AddCustomer(newTestCustomer);
            //Assert
            Assert.AreEqual(noOfCustomers+1, testRepo.Customers.Count);
        }
    }
}
