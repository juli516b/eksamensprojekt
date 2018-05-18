using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.BaseTypes;

namespace RabatmanTests
{
    [TestClass]
    public class OfferTest
    {
        [TestMethod]
        public void AddOfferLineToOffer()
        {
            //Arrange
            IBaseItem item = new Item("PommesDeluxe", "12345678", 25.95, "Frankrig", 25);
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
            IBaseItem item = new Item("PommesDeluxe", "12345678", 10.5, "Frankrig", 25);
            OfferLine offerLine1 = new OfferLine(item, 2);
            //Act
            //Assert
            Assert.AreEqual(21, offerLine1.OfferLineTotal);
        }
        [TestMethod]
        public void RemoveOfferLineTest()
        {
            //Arrange
            IBaseItem item = new Item("PommesDeluxe", "12345678", 25.95, "Frankrig", 25);
            OfferLine offerLine = new OfferLine(item, 20);
            Offer offer = new Offer(DateTime.Now);
            offer.AddOfferLine(offerLine);
            Assert.AreEqual(1, offer.OfferLines.Count);
            //Act
            offer.RemoveOfferLine(offerLine);
            //Assert
            Assert.AreEqual(0, offer.OfferLines.Count);
        }
        [TestMethod]
        public void TestOfferTotal()
        {
            //Arrange
            IBaseItem item = new Item("PommesDeluxe", "12345678", 10.5, "Frankrig", 25);
            IBaseItem item2 = new Item("PommesDeluxe2", "123456782", 20.25, "Frankrig", 25);
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
        [TestMethod]
        public void TestOfferDiscount()
        {
            //Arrange
            IBaseItem item = new Item("PommesDeluxe", "12345678", 1, "Frankrig", 25);
            IBaseItem item2 = new Item("PommesDeluxe", "12345678", 2.50, "Frankrig", 25);
            Offer offer = new Offer(DateTime.Now);
            OfferLine offerLine = new OfferLine(item, 100);

            //Act
            offer.AddOfferLine(offerLine);
            offer.OfferDiscount = 20;

            //Assert
            Assert.AreEqual(80, offer.OfferTotal);
            OfferLine offerLine2 = new OfferLine(item2, 4);
            offer.AddOfferLine(offerLine2);
            Assert.AreEqual(88, offer.OfferTotal);
            offer.OfferDiscount = 10;
            Assert.AreEqual(99, offer.OfferTotal);
            OfferLine offerLine3 = new OfferLine(item, 100)
            {
                PercentDiscount = 20
            };
            offer.AddOfferLine(offerLine3);
            Assert.AreEqual(171, offer.OfferTotal);
        }
    }
}
