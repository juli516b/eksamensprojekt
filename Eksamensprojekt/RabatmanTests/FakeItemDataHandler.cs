using System.Collections.Generic;
using Model.BaseTypes;
using DataAccessLayer.DataHandlers;
using System.Collections.ObjectModel;

namespace RabatmanTests
{
    public class FakeItemDataHandler : IPersistentItemDataHandler
    {
        public ObservableCollection<IBaseItem> Items { get; set; }
        public ObservableCollection<IBaseItem> GetAllItems()
        {
            return new ObservableCollection<IBaseItem>();
        }
    }
}
