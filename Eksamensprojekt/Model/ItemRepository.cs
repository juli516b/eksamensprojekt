using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ItemRepository
    {
        public IList<IItem> Items { get; set; }
        public ItemRepository()
        {
            Items = new List<IItem>();
        }
        public bool AddItem(IItem item)
        {
            // tilføj kode til at gemme i DB
            bool isSuccessful = false;
            Items.Add(item);
            if (Items.Contains(item))
            {
                isSuccessful = true;
            }
            return isSuccessful;
        }
    }
}
