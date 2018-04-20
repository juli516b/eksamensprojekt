using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Model
{
    public class OfferLine:INotifyPropertyChanged
    {
        private IItem item;
        private int quantity;
        public string ItemNo { get {return Item.ItemNo; } }

        public string ItemName { get { return Item.ItemName; } }
        public double ItemPrice { get { return Item.ItemPrice; } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotityPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
            
        }

        public IItem Item
        {
            get { return item; }
            set
            {
                item = value;
                NotityPropertyChanged("Item");
                NotityPropertyChanged("OfferLineTotal");
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value;
                NotityPropertyChanged("Quantity");
                NotityPropertyChanged("OfferLineTotal");
            }
        }

        public double OfferLineTotal
        {
            get { return Quantity*ItemPrice; }
            
        }

        public OfferLine(IItem item, int quantity)
        {
            Quantity = quantity;
            Item = item;
        }
    }
}
