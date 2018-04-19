using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    class OfferViewModel
    {
        public Offer ThisOffer { get; set; }
        public IList<IItem> Items { get; set; }

        public Offer CreateOffer(DateTime creationDate)
        {
            Offer newOffer = new Offer(creationDate);
            return newOffer;
        }
        public void AddOfferLine(Offer thisOffer, IItem item, int quantity)
        {
            OfferLine newOfferLine = new OfferLine(item, quantity);
            thisOffer.AddOfferLine(newOfferLine);
        }
    }
}
