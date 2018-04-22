using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ItemRepository
    {
        public IList<IBaseItem> Items { get; set; }
        public ItemRepository(IPersistentDataHandler persistentDataHandler)
        {
            Items = new List<IBaseItem>();
            persistentDataHandler.GetAll(Items);
        }
        public bool AddItem(IBaseItem item)
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
