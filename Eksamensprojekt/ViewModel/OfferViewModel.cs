using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class OfferViewModel : INotifyPropertyChanged
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
                APropertyChanged(nameof(OfferLines));
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
                APropertyChanged(nameof(OfferTotal));
            }
        }
        private double offerTotal;
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
            set
            {
                offerTotal = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(OfferTotal)));
            }
        }

        public OfferViewModel()
        {
            ThisOffer = CreateOffer(DateTime.Now);
        }
        public Offer ThisOffer { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void APropertyChanged(string property)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        public Offer CreateOffer(DateTime creationDate)
        {
            Offer newOffer = new Offer(creationDate);
            return newOffer;
        }

        public void AddOfferLine(Offer thisOffer, IBaseItem item, int quantity)
        {
            OfferLine newOfferLine = new OfferLine(item, quantity);
            newOfferLine.APC += APropertyChanged;
            thisOffer.AddOfferLine(newOfferLine);
            APropertyChanged(nameof(OfferTotal));
        }
    }
}
