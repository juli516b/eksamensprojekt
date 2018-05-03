using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Model
{
    public class Offer
    {
        private ObservableCollection<OfferLine> _offerLines;

        public Customer MyCustomer { get; set; }
        public string OfferNo { get; set; }
        public DateTime OfferDate { get; set; }
        public double OfferTotal
        {
            get
            {
                double total = 0;
                total += OfferLines.Sum(offerLine => offerLine.OfferLineTotal);
                total = DiscountMath.PercentToPrice(OfferDiscount, total);
                return total;
            }
            set
            {
                return;
            }
        }

        public ObservableCollection<OfferLine> OfferLines { get => _offerLines;
            set
            {
                _offerLines = value;
            }
        }
        public double OfferDiscount { get; set; }
        public Offer(DateTime creationDate)
        {
            OfferDate = creationDate;
            OfferLines = new ObservableCollection<OfferLine>();
        }
        public void AddOfferLine(OfferLine offerLine)
        {
            OfferLines.Add(offerLine);
        }
    }
}
