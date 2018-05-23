using System.Collections.Generic;
using Model.BaseTypes;
using DataAccessLayer.DataHandlers;

namespace DataAccessLayer
{
    public class ItemRepository
    {
        public IList<IBaseItem> Items { get; set; }
        private ItemRepository(IPersistentItemDataHandler persistentDataHandler)
        {
            Items = new List<IBaseItem>();
            Items = persistentDataHandler.GetAll(Items);
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
        private static ItemRepository instance;

        public static ItemRepository GetInstance(IPersistentItemDataHandler dataHandler)
        {
            if (instance == null)
            {
                instance = new ItemRepository(dataHandler);
                    
            }
            return instance;
        }
    }
}
