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
        public string ItemPriceF2
        {
            get { return ItemPrice.ToString($"F2"); }
        }
        public Item(string itemName, string itemNo, double itemPrice)
        {
            ItemName = itemName;
            ItemNo = itemNo;
            ItemPrice = itemPrice;
        }
    }
}
