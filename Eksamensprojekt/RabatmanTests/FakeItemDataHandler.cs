using System.Collections.Generic;
using Model.BaseTypes;
using Model.DataHandlers;

namespace RabatmanTests
{
    public class FakeItemDataHandler : IPersistentItemDataHandler
    {
        public IList<IBaseItem> GetAll(IList<IBaseItem> items)
        {
            return items;
        }
    }
}
