using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class ViewModel
    {
        ItemRepository itemRepository = new ItemRepository();
        public string AddItem(string itemName, string itemNo, double itemPrice)
        {
            Item item = new Item(itemName, itemNo, itemPrice);
            string processMessage = "Varen blev ikke tilføjet";
            if (itemRepository.AddItem(item))
            {
                processMessage = "Varen blev tilføjet";
            }
            return processMessage;
        }
    }
}
