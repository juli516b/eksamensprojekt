using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Model
{

    public delegate void APropertyChanged(string property);
    public class OfferLine:INotifyPropertyChanged
    {
        public event APropertyChanged APC;
        private IBaseItem item;
        private int quantity;
        private double percentDiscount;
        private double discountedPrice;
        public string ItemNo { get {return Item.ItemNo; } }
        public string ItemName { get { return Item.ItemName; } }
        public double ItemPrice {
            get
            {
                double returnPrice = Item.ItemPrice;
                if (discountedPrice > 0)
                {
                    returnPrice = discountedPrice;
                }
                return returnPrice;
            }
        }
        public double PercentDiscount
        {
            get { return percentDiscount; }
            set
            {
                percentDiscount = value;
                if (discountedPrice == 0 || discountedPrice != DiscountMath.PercentToPrice(PercentDiscount, Item.ItemPrice))
                {
                    DiscountedPrice = DiscountMath.PercentToPrice(PercentDiscount, Item.ItemPrice);
                    NotifyPropertyChanged(nameof(DiscountedPrice));
                    NotifyPropertyChanged(nameof(PercentDiscount));
                    NotifyPropertyChanged(nameof(OfferLineTotal));
                    APC?.Invoke("OfferTotal");
                }
            }
        }
        public double DiscountedPrice
        {
            get { return discountedPrice; }
            set
            {
                discountedPrice = value;
                if (percentDiscount == 0 || percentDiscount != DiscountMath.PriceToPercent(DiscountedPrice, Item.ItemPrice))
                {
                    PercentDiscount = DiscountMath.PriceToPercent(DiscountedPrice, Item.ItemPrice);
                    NotifyPropertyChanged(nameof(DiscountedPrice));
                    NotifyPropertyChanged(nameof(PercentDiscount));
                    NotifyPropertyChanged(nameof(OfferLineTotal));
                    APC?.Invoke("OfferTotal");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
            
        }

        public IBaseItem Item
        {
            get { return item; }
            set
            {
                item = value;
                NotifyPropertyChanged("Item");
                NotifyPropertyChanged("OfferLineTotal");
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value;
                NotifyPropertyChanged("Quantity");
                NotifyPropertyChanged("OfferLineTotal");
            }
        }

        public double OfferLineTotal
        {
            get
            {
                if (DiscountedPrice==0)
                {
                    return Quantity * ItemPrice;
                }
                return DiscountedPrice * Quantity;
            }   
        }

        public OfferLine(IBaseItem item, int quantity)
        {
            Quantity = quantity;
            Item = item;
        }
    }
}
