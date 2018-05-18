using System;
using Model.BaseTypes;

namespace Model
{
    public class Item : IBaseItem
    {
      
        public string ItemName { get; set; }
        public string ItemNo { get; set; }
        public double ItemPrice { get; set; }
        public double ItemWeight { get; set; }
        public double ItemPriceF2
        {
            get { return Math.Round(ItemPrice, 2); }
        }
        public int CountPerPallet { get; set; }
        public Item(string itemName, string itemNo, double itemPrice, double itemWeight)
        {
            ItemName = itemName;
            ItemNo = itemNo;
            ItemPrice = itemPrice;
            ItemWeight = itemWeight;
        }
        public Item(string itemName, string itemNo, double itemPrice, double itemWeight, int noOnPallet) : this(itemName, itemNo, itemPrice, itemWeight)
        {
            CountPerPallet = noOnPallet;
        }
    }
}
