using System;
using System.Collections.ObjectModel;
using System.Linq;
using Model.BaseTypes;

namespace Model
{
    public class Offer : IBaseOffer
    {
        public DateTime OfferCreationDate { get; set; }

        public Customer MyCustomer { get; set; }
        public int? OfferNo { get; set; }

        public double OfferTotal
        {
            get
            {
                double total = 0;
                total += OfferLines.Sum(offerLine => offerLine.OfferLineTotal);
                total = DiscountMath.PercentToPrice(OfferDiscountPercent, total);
                if (MyCustomer != null)
                {
                    total = DiscountMath.PercentToPrice(MyCustomer.CustomerDiscountPercent, total);
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

        public double OfferDiscountPercent { get; set; }
        public double ForwardingAgentPrice { get; set; }

        public Offer(DateTime creationDate)
        {
            OfferCreationDate = creationDate;
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
            OfferCreationDate = DateTime.Now;
            MyCustomer = null;
            OfferNo = null;
            ForwardingAgentPrice = 0;
            OfferDiscountPercent = 0;
            OfferLines.Clear();
        }
    }
}
