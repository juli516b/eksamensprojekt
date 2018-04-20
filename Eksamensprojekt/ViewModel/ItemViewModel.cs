using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class ItemViewModel
    {
        private static ItemViewModel instance;
        ItemRepository itemRepository = new ItemRepository(new ItemDataHandler());
        public IList<IItem> Items { get; set; }
        private ItemViewModel()
        {
            Items = itemRepository.Items;
        }
        public static ItemViewModel GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ItemViewModel();
                }
                return instance;
            }
        }
    }
}
