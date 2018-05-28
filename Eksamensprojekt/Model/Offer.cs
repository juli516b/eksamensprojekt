using System;
using System.Collections.ObjectModel;
using System.Linq;
using Model.BaseTypes;

namespace Model
{
    public class Offer : IExtendOffer
    {
        public DateTime OfferCreationDate { get; set; }

        public IBaseCustomer MyCustomer { get; set; }
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
        }

        public double OfferSubTotal
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
                if (OfferSubTotal != 0)
                {
                    double roundedValue = Math.Round(DiscountMath.PriceToPercent(CalculateOffertotalWithoutForwardingAgentPrice(), OfferSubTotal), 2);
                    return roundedValue + " %";
                }
                return "0 %";
            }
            private set => TotalPercentDiscount = value;
        }

        public string TotalDiscountedPrice => OfferSubTotal - CalculateOffertotalWithoutForwardingAgentPrice() + " DKK";

        public ObservableCollection<IExtendOfferLine> OfferLines { get; set; }

        public double OfferDiscountPercent { get; set; }
        public double ForwardingAgentPrice { get; set; }

        public Offer(DateTime creationDate)
        {
            OfferCreationDate = creationDate;
            OfferLines = new ObservableCollection<IExtendOfferLine>();
        }
        public void AddOfferLine(IExtendOfferLine offerLine)
        {
            OfferLines.Add(offerLine);
        }

        public void RemoveOfferLine(IExtendOfferLine offerLine)
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
