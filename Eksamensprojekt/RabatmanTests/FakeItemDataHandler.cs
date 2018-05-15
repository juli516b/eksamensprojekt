using System.Collections.Generic;
using Model;
using Model.BaseTypes;

namespace RabatmanItemTest
{
    public class FakeItemDataHandler : IPersistentItemDataHandler
    {
        public IList<IBaseItem> GetAll(IList<IBaseItem> items)
        {
            return items;
        }
    }
}
