using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.BaseTypes;
using DataAccessLayer.DataHandlers;
using ViewModel;
using DataAccessLayer;

namespace RabatmanTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ViewModelTest
    {
        [TestMethod]
        public void TestOfferDiscountdims()
        {
            //Arrange
            OfferViewModel novm = new OfferViewModel();
            IBaseItem item = new Item("PommesDeluxe", "12345678", 1, 25);
            IBaseItem item2 = new Item("PommesDeluxe", "12345678", 2.50, 25); 

            //Act
            //Assert
            Assert.AreEqual(0 + " DKK", novm.OfferTotal); //No offerLines added
            novm.AddOfferLine(item, 100);
            Assert.AreEqual(100 + " DKK", novm.OfferTotal); //One offerline added and OfferTotal = 100
            novm.OfferDiscountPercent = 20;
            Assert.AreEqual(80 + " DKK", novm.OfferTotal); //OfferDiscount set to 20 (%): OfferTotal = 80
            novm.AddOfferLine(item2,4);
            Assert.AreEqual(88 + " DKK", novm.OfferTotal); //Another offerline added: OfferTotal = (100 + 10) *0,8 = 88 
            novm.OfferDiscountPercent = 10;
            Assert.AreEqual(99 + " DKK", novm.OfferTotal); //OfferDiscount corrected to 10 (%): OfferTotal = (100 + 10) * 0,9 = 99
            novm.AddOfferLine(item,100);
            novm.OfferLines[2].PercentDiscount = 20;
            Assert.AreEqual(171 + " DKK", novm.OfferTotal); //Yet another offerline added with discount set to 20: OfferTotal = (100 + 10 + 100 * 0,8) * 0,9 = 171

        }
        [TestMethod]
        public void NumberOfPallets()
        {
            //Arrange
            OfferViewModel ovm = new OfferViewModel();
            IBaseItem item = new Item("PommesDeluxe", "12345678", 1, 25, 10);
            IBaseItem item2 = new Item("PommesDeluxe", "12345678", 2.5, 25, 25);

            //Act
            ovm.AddOfferLine(item, 27);

            //Assert
            Assert.AreEqual(2, ovm.NoOfTotalPallets);
            Assert.AreEqual(7, ovm.NoOfTotalPackages);
            ovm.AddOfferLine(item2, 31);
            Assert.AreEqual(3, ovm.NoOfTotalPallets);
            Assert.AreEqual(13, ovm.NoOfTotalPackages);
        }
        [TestMethod]
        public void AddCustomerTest()
        {
            //Arrange
            IPersistentCustomerDataHandler cdh = new FakeCustomerDataHandler();
            CreateCustomerViewModel createCustomerViewModel = new CreateCustomerViewModel(cdh);
            
            //Act
            cdh.Customers = cdh.GetAllCustomers();
            int noOfCustomers = cdh.Customers.Count;
            createCustomerViewModel.CustomerName = "Mig";
            createCustomerViewModel.AddNewCustomer();

            //Assert
            Assert.AreEqual(noOfCustomers + 1, cdh.Customers.Count);
        }
    }
}
