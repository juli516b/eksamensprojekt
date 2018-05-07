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
            CreateCustomerViewModel createCustomerViewModel = new CreateCustomerViewModel();
            //Act
            createCustomerViewModel.CustomerName = "Mig";
            createCustomerViewModel.AddNewCustomer();
            //Assert
            Assert.AreEqual(1, CustomerRepository.GetInstance().Customers.Count);
        }
    }
}
