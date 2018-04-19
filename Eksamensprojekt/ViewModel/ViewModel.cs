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
        private static ViewModel instance;
        ItemRepository itemRepository = new ItemRepository(new ItemDataHandler());
        public IList<IItem> Items { get; set; }
        private ViewModel()
        {
            Items = itemRepository.Items;
        }
        /*public string AddItem(string itemName, string itemNo, double itemPrice)
        {
            Item item = new Item(itemName, itemNo, itemPrice);
            string processMessage = "Varen blev ikke tilføjet";
            if (itemRepository.AddItem(item))
            {
                processMessage = "Varen blev tilføjet";
            }
            return processMessage;
        }*/
        public static ViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new ViewModel();
            }
            return instance;
        }
    }
}
