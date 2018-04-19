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
        public static ViewModel GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ViewModel();
                }
                return instance;
            }
        }
    }
}
