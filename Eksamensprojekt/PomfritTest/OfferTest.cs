using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace RabatmanOfferTest
{
    [TestClass]
    public class OfferTest
    {
        [TestMethod]
        public void AddOfferLineToOffer()
        {
            //Arrange
            IItem item = new Item("PommesDeluxe", "12345678", 25.95);
            OfferLine offerLine = new OfferLine(item, 20);
            Offer offer = new Offer(DateTime.Now);
            //Act
            offer.AddOfferLine(offerLine);
            //Assert
            Assert.AreEqual(1, offer.OfferLines.Count);
        }
        [TestMethod]
        public void TestOfferLineTotal()
        {
            //Arrange
            IItem item = new Item("PommesDeluxe", "12345678", 10.5);
            OfferLine offerLine1 = new OfferLine(item, 2);
            //Act
            //Assert
            Assert.AreEqual(21, offerLine1.OfferLineTotal);
        }
        [TestMethod]
        public void TestOfferTotal()
        {
            //Arrange
            IItem item = new Item("PommesDeluxe", "12345678", 10.5);
            IItem item2 = new Item("PommesDeluxe2", "123456782", 20.25);
            Offer testOffer = new Offer(new DateTime(2017, 11, 01));
            OfferLine offerLine1 = new OfferLine(item, 5); //52.5 total
            OfferLine offerLine2 = new OfferLine(item2, 10); //202,5 total
            //Act
            //Assert
            Assert.AreEqual(0, testOffer.OfferTotal);
            testOffer.AddOfferLine(offerLine1);
            Assert.AreEqual(52.5, testOffer.OfferTotal);
            testOffer.AddOfferLine(offerLine2);
            Assert.AreEqual(255, testOffer.OfferTotal);
        }
    }
}
