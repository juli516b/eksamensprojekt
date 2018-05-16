﻿using System.ComponentModel;
using Model.BaseTypes;

namespace Model
{

    public delegate void APropertyWasChanged(string propertyName);
    public class OfferLine : INotifyPropertyChanged
    {
        public event APropertyWasChanged APWC;
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyAPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private IBaseItem item;
        private int quantity;
        private double percentDiscount;
        private double discountedPrice;

        public string ItemNo { get {return Item.ItemNo; } }
        public string ItemName { get { return Item.ItemName; } }
        public string ItemCountry { get { return Item.ItemCountry; } } //update artefakt
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
            get { return System.Math.Round(percentDiscount,2); }
            set
            {
                percentDiscount = value;
                if (discountedPrice == 0 || discountedPrice != DiscountMath.PercentToPrice(PercentDiscount, Item.ItemPrice))
                {
                    DiscountedPrice = DiscountMath.PercentToPrice(PercentDiscount, Item.ItemPrice);
                    NotifyAPropertyChanged("DiscountedPrice");
                    NotifyAPropertyChanged("OfferLineTotal");
                    APWC?.Invoke("OfferTotal");
                    APWC?.Invoke("OfferLinesSubtotal");
                    APWC?.Invoke("TotalDiscountedPrice");
                    APWC?.Invoke("TotalPercentedPrice");
                }
            }
        }
        public double DiscountedPrice
        {
            get { return System.Math.Round(discountedPrice, 2); }
            set
            {
                discountedPrice = value;
                if (percentDiscount == 0 || percentDiscount != DiscountMath.PriceToPercent(DiscountedPrice, Item.ItemPrice))
                {
                    PercentDiscount = DiscountMath.PriceToPercent(DiscountedPrice, Item.ItemPrice);
                    NotifyAPropertyChanged("PercentDiscount");
                    NotifyAPropertyChanged("OfferLineTotal");
                    APWC?.Invoke("OfferTotal");
                    APWC?.Invoke("OfferLinesSubtotal");
                    APWC?.Invoke("TotalDiscountedPrice");
                    APWC?.Invoke("TotalPercentedPrice");
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
                if (DiscountedPrice==0)
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
