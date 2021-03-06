﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.BaseTypes;

namespace RabatmanTests
{
    [TestClass]
    public class OfferLineTest
    {
        [TestMethod]
        public void OfferLineTotalTest()
        {
            //Arrange
            IBaseItem item = new Item("Kyllinge vinger", "123", 20.25, 25);
            OfferLine offerLine = new OfferLine(item, 100);
            //Act
            //Assert
            Assert.AreEqual(2025, offerLine.OfferLineTotal);
        }
        [TestMethod]
        public void DiscountedPriceMathTest()
        {
            //Arrange
            IBaseItem item = new Item("Kyllinge vinger", "123", 20.25, 25);
            OfferLine offerLine = new OfferLine(item, 100) {DiscountedPrice = 15};
            //Act
            //Assert
            Assert.AreEqual(1500, offerLine.OfferLineTotal);
            Assert.AreEqual(25.9259259259, offerLine.PercentDiscount, 5);
        }
        [TestMethod]
        public void PercentDiscountMathTest()
        {
            //Arrange
            IBaseItem item = new Item("Kyllinge vinger", "123", 20.25, 25);
            OfferLine offerLine = new OfferLine(item, 100) {PercentDiscount = 20};
            //Act
            //Assert
            Assert.AreEqual(1620, offerLine.OfferLineTotal);
            Assert.AreEqual(16.2, offerLine.DiscountedPrice);
        }
    }
}
