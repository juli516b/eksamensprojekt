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
        private double offerTotal;

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
            get { return offerTotal; }
            set { offerTotal = value; }
        }

        public Offer(DateTime creationDate)
        {
            OfferDate = creationDate;
        }

        public void AddOfferLine(OfferLine offerLine)   
        {
            OfferLines.Add(offerLine);
        }



    }
}
