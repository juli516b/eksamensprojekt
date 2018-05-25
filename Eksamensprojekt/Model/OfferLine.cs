using System;
using System.ComponentModel;
using Model.BaseTypes;

namespace Model
{

    public delegate void APropertyWasChanged(string propertyName);
    public class OfferLine : INotifyPropertyChanged, IBaseOfferLine
    {
        public event APropertyWasChanged APWC;
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyAPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public int OfferLineId { get; set; }
        private IBaseItem item;
        private int quantity;
        private double percentDiscount;
        private double discountedPrice;

        public string ItemNo { get {return Item.ItemNo; } }
        public string ItemName { get { return Item.ItemName; } }
        public double ItemWeight { get { return Item.ItemWeight; } } //update artefakt
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
            get { return Math.Round(percentDiscount,2); }
            set
            {
                percentDiscount = value;
                //GØR DET HER PÆNERE - SPØRG VEJLEDER
                if (Math.Abs(discountedPrice) <  Double.Epsilon || Math.Abs(discountedPrice - DiscountMath.PercentToPrice(PercentDiscount, Item.ItemPrice)) > Double.Epsilon)
                {
                    DiscountedPrice = DiscountMath.PercentToPrice(PercentDiscount, Item.ItemPrice);
                    NotifyAPropertyChanged("DiscountedPrice");
                    NotifyAPropertyChanged("OfferLineTotal");
                    APWC?.Invoke("OfferTotal");
                    APWC?.Invoke("OfferLinesSubtotal");
                    APWC?.Invoke("TotalDiscountedPrice");
                    APWC?.Invoke("TotalPercentDiscount");
                }
            }
        }
        public double DiscountedPrice
        {
            get { return Math.Round(discountedPrice, 2); }
            set
            {
                discountedPrice = value;
                //GØR DET HER PÆNERE - SPØRG VEJLEDER
                if (Math.Abs(percentDiscount) < Double.Epsilon || Math.Abs(percentDiscount - DiscountMath.PriceToPercent(DiscountedPrice, Item.ItemPrice)) > Double.Epsilon)
                {
                    PercentDiscount = DiscountMath.PriceToPercent(DiscountedPrice, Item.ItemPrice);
                    NotifyAPropertyChanged("PercentDiscount");
                    NotifyAPropertyChanged("OfferLineTotal");
                    APWC?.Invoke("OfferTotal");
                    APWC?.Invoke("OfferLinesSubtotal");
                    APWC?.Invoke("TotalDiscountedPrice");
                    APWC?.Invoke("TotalPercentDiscount");
                }
            }
        }
        public IBaseItem Item
        {
            get { return item; }
            set
            {
                item = value;
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set {
                quantity = value;
                NotifyAPropertyChanged("OfferLineTotal");
                NotifyAPropertyChanged("NoOfPallets");
                NotifyAPropertyChanged("NoOfPackages");
                APWC?.Invoke("OfferTotal");
                APWC?.Invoke("NoOfTotalPallets");
                APWC?.Invoke("NoOfTotalPackages");
                APWC?.Invoke("OfferLinesSubtotal");
            }
        }

        public double OfferLineTotal
        {
            get
            {
                if(PercentDiscount > 100)
                {
                    PercentDiscount = 0;
                }
                if(PercentDiscount == 100)
                {
                    return 0;
                }
                if (DiscountedPrice == 0 && PercentDiscount != 100)

                {
                    return Quantity * ItemPrice;
                }
                return DiscountedPrice * Quantity;
            }   
        }

        public int NoOfPallets
        {
            get
            {
                return Quantity / Item.CountPerPallet;
            }
        }
        public int NoOfPackages
        {
            get
            {
                return Quantity % Item.CountPerPallet;
            }
        }

        public OfferLine(IBaseItem item, int quantity)
        {
            Quantity = quantity;
            Item = item;
        }
    }
}
