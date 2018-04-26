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
        public IList<IBaseItem> Items
        {
            get
            {
                return ItemRepository.Instance.Items;
            }
        }
        public IList<OfferLine> OfferLines
        {
            get
            {
                return ThisOffer.OfferLines;
            }
            set
            {
                ThisOffer.OfferLines = value;
            }
        }
        public double OfferDiscount
        {
            get
            {
                return ThisOffer.OfferDiscount;
            }
            set
            {
                ThisOffer.OfferDiscount = value;
                //Property kan ændres!
            }
        }
        public double OfferTotal
        {
            get
            {
              double total = OfferLines.Sum(offerLine => offerLine.OfferLineTotal);
                if (OfferDiscount > 0)
                {
                    total = DiscountMath.PercentToPrice(OfferDiscount, total);
                }
                return total;
            }
        }

        public OfferViewModel()
        {
            ThisOffer = CreateOffer(DateTime.Now);
        }
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
        public void UpdateOfferTotal()
        {
            ThisOffer.SumOfferLines();
        }
    }
}
