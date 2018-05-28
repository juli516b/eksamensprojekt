using System.Collections.Generic;
using System.Collections.ObjectModel;
using Model.BaseTypes;

namespace DataAccessLayer.DataHandlers
{
    public interface IPersistentItemDataHandler
    {
        ObservableCollection<IBaseItem> Items { get; set; }
        ObservableCollection<IBaseItem> GetAllItems();
        // IBaseItem SaveItem(IBaseItem newItem);
    }
}
