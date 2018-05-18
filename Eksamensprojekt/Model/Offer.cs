using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Model
{
    public class Offer
    {
        public DateTime? CreationDate { get; set; }

        public Customer MyCustomer { get; set; }
        public string OfferNo { get; set; }

        public double OfferTotal
        {
            get
            {
                double total = 0;
                total += OfferLines.Sum(offerLine => offerLine.OfferLineTotal);
                total = DiscountMath.PercentToPrice(OfferDiscount, total);
                if (MyCustomer != null)
                {
                    total = DiscountMath.PercentToPrice(MyCustomer.CustomerDiscount, total);
                }
                if (ForwardingAgentPrice > 0)
                {
                    total += ForwardingAgentPrice;
                }
                return total;
            }
            set => throw new NotImplementedException();
        }

        public double OfferSubtotal
        {
            get
            {
                double offerSubtotal = OfferLines.Sum(offerLine => offerLine.Item.ItemPrice * offerLine.Quantity);
                return offerSubtotal;
            }
        }

        public string TotalPercentDiscount
        {
            get
            {
                if (OfferSubtotal != 0)
                {
                    double roundedValue = Math.Round(DiscountMath.PriceToPercent(CalculateOffertotalWithoutForwardingAgentPrice(), OfferSubtotal), 2);
                    return roundedValue + " %";
                }
                return "0 %";
            }
            private set => TotalPercentDiscount = value;
        }

        public string TotalDiscountedPrice => OfferSubtotal - CalculateOffertotalWithoutForwardingAgentPrice() + " DKK";

        public ObservableCollection<OfferLine> OfferLines { get; set; }

        public double OfferDiscount { get; set; }
        public double ForwardingAgentPrice { get; set; }

        public Offer(DateTime creationDate)
        {
            CreationDate = creationDate;
            OfferLines = new ObservableCollection<OfferLine>();
        }
        public void AddOfferLine(OfferLine offerLine)
        {
            OfferLines.Add(offerLine);
        }

        public void RemoveOfferLine(OfferLine offerLine)
        {
            OfferLines.Remove(offerLine);
        }
        private double CalculateOffertotalWithoutForwardingAgentPrice()
        {
            return OfferTotal - ForwardingAgentPrice;
        }

        public void Clear()
        {
            CreationDate = null;
            MyCustomer = null;
            OfferNo = null;
            OfferLines.Clear();
        }
    }
}
