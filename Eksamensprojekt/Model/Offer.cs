using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Model
{
    public class Offer:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }

        }
        public double OfferDiscount { get; set; }

        public string OfferNo { get; set; }

        public DateTime OfferDate { get; set; }

        public IList<OfferLine> OfferLines { get; set; }

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

        public Offer(DateTime creationDate)
        {
            OfferDate = creationDate;
            OfferLines = new List<OfferLine>();
        }

        public void AddOfferLine(OfferLine offerLine)   
        {
            OfferLines.Add(offerLine);
            NotifyPropertyChanged("OfferTotal");
        }
        public void SumOfferLines()
        {
            NotifyPropertyChanged("OfferTotal");            
        }
    }
}
