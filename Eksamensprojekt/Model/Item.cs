using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Item : IItem
    {
        private string itemName;
        private string itemNo;
        private double itemPrice;

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
        public string ItemNo
        {
            get { return itemNo; }
            set { itemNo = value; }
        }
        public double ItemPrice
        {
            get { return itemPrice; }
            set { itemPrice = value; }
        }
        public string ItemPriceF2
        {
            get { return itemPrice.ToString($"F2"); }
        }
        public Item(string itemName, string itemNo, double itemPrice)
        {
            ItemName = itemName;
            ItemNo = itemNo;
            ItemPrice = itemPrice;
        }
    }
}
