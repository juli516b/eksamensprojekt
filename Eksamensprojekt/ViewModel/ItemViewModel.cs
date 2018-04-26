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
        public IList<IBaseItem> Items { get; set; }
        private ItemViewModel()
        {
            Items = ItemRepository.Instance.Items;
        }
        public static ItemViewModel Instance
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
