using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace RabatmanItemTest
{
    public class FakeItemDataHandler : IPersistentDataHandler
    {
        public IList<IBaseItem> GetAll(IList<IBaseItem> items)
        {
            return items;
        }
    }
}
