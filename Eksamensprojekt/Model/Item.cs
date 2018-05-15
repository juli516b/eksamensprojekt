using System;
using Model.BaseTypes;

namespace Model
{
    public class Item : IBaseItem
    {
        public string ItemName { get; set; }
        public string ItemNo { get; set; }
        public double ItemPrice { get; set; }
        public string ItemCountry { get; set; } //Artefakter skal lige updateres MathiasX
        public double ItemWeight { get; set; } //Samme her MathiasX
        public string ItemPriceF2
        {
            get { return Math.Round(ItemPrice,2).ToString($"F2"); }
        }
        public int CountPerPallet { get; set; }
        public Item(string itemName, string itemNo, double itemPrice, string itemCountry, double itemWeight)
        {
            ItemName = itemName;
            ItemNo = itemNo;
            ItemPrice = itemPrice;
            ItemCountry = itemCountry;
            ItemWeight = itemWeight;
        }
        public Item(string itemName, string itemNo, double itemPrice, string itemCountry, double itemWeight, int noOnPallet) : this(itemName, itemNo, itemPrice, itemCountry, itemWeight)
        {
            CountPerPallet = noOnPallet;
        }
    }
}
