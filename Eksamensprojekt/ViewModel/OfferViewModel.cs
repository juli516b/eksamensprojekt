using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class OfferViewModel
    {
        private OfferViewModel()
        {
            ThisOffer = CreateOffer(DateTime.Now);
        }
        private static OfferViewModel instance;
        public Offer ThisOffer { get; set; }
        public Offer CreateOffer(DateTime creationDate)
        {
            Offer newOffer = new Offer(creationDate);
            return newOffer;
        }
        public void AddOfferLine(Offer thisOffer, IBaseItem item, int quantity)
        {
            OfferLine newOfferLine = new OfferLine(item, quantity);
            thisOffer.AddOfferLine(newOfferLine);
        }
        public void PriceToPercent(OfferLine offerLine, double newPrice)
        {
            offerLine.DiscountedPrice = newPrice;
        }
        public void PercentToPrice(OfferLine offerLine, double percent)
        {

        }
      
        public static OfferViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OfferViewModel();
                }
                return instance;
            }
        }
    }
}
