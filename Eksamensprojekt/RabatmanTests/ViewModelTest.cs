using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using ViewModel;

namespace RabatmanViewModelTest
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
            IBaseItem item = new Item("PommesDeluxe", "12345678", 1);
            IBaseItem item2 = new Item("PommesDeluxe", "12345678", 2.50);
            //OfferLine offerLine = new OfferLine(item, 100);
            Assert.AreEqual(0, novm.OfferTotal);
            novm.AddOfferLine(item, 100);
            Assert.AreEqual(100, novm.OfferTotal);
            novm.OfferDiscount = "20";
            //Act
            

            //Assert
            //Assert.AreEqual(80, novm.OfferTotal);
            //OfferLine offerLine2 = new OfferLine(item2, 4);
            //offer.AddOfferLine(offerLine2);
            //Assert.AreEqual(88, offer.OfferTotal);
            //offer.OfferDiscount = 10;
            //Assert.AreEqual(99, offer.OfferTotal);
            //OfferLine offerLine3 = new OfferLine(item, 100);
            //offerLine3.PercentDiscount = 20;
            //offer.AddOfferLine(offerLine3);
            //Assert.AreEqual(171, offer.OfferTotal);

        }
    }
}
