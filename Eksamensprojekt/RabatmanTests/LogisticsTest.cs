using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.BaseTypes;
using ViewModel;

namespace PomfritTest
{
    [TestClass]
    class LogisticsTest
    {
        [TestMethod]
        public void FWAgentPriceUpdatesOfferTotal()
        {
            //Arrange
            OfferViewModel ovm = new OfferViewModel();
            IBaseItem item = new Item("PommesDeluxe", "12345678", 50);

            //Act
            ovm.AddOfferLine(item, 30);
            Assert.AreEqual(ovm.OfferTotal, 1500);
            ovm.ForwardingAgentPrice = 200;

            //Assert
            Assert.AreEqual(1700, ovm.OfferTotal);
        }
    }
}
