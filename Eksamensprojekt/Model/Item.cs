using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Item : IBaseItem
    {
        public string ItemName { get; set; }
        public string ItemNo { get; set; }
        public double ItemPrice { get; set; }
        public string ItemCountry { get; set; } //Artefakter skal lige updateres MathiasX
        public string ItemPriceF2
        {
            get { return Math.Round(ItemPrice,2).ToString($"F2"); }
        }
        public int CountPerPallet { get; set; }
        public Item(string itemName, string itemNo, double itemPrice, string itemCountry)
        {
            ItemName = itemName;
            ItemNo = itemNo;
            ItemPrice = itemPrice;
            ItemCountry = itemCountry;
        }
        public Item(string itemName, string itemNo, double itemPrice, string itemCountry, int noOnPallet) : this(itemName, itemNo, itemPrice, itemCountry)
        {
            CountPerPallet = noOnPallet;
        }
    }
}
