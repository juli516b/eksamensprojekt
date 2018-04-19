using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OfferLine
    {
        private IItem item;
        private int quantity;
        private double offerLineTotal;

        public IItem Item
        {
            get { return item; }
            set { item = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public double OfferLineTotal
        {
            get { return offerLineTotal; }
            set { offerLineTotal = value; }
        }

        public OfferLine(IItem item, int quantity)
        {
            Quantity = quantity;
            Item = item;
        }
    }
}
