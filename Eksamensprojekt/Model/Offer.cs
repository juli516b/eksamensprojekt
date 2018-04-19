using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
    public class Offer
    {
        private string offerNo;
        private DateTime offerDate;
        private IList<OfferLine> offerLines;
        

        public string OfferNo
        {
            get { return offerNo; }
            set { offerNo = value; }
        }

        public DateTime OfferDate
        {
            get { return offerDate; }
            set { offerDate = value; }
        }

        public IList<OfferLine> OfferLines
        {
            get { return offerLines; }
            set { offerLines = value; }
        }

        public double OfferTotal
        {
            get { double total = OfferLines.Sum(x => x.OfferLineTotal);
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
        }



    }
}
