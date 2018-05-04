using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IPersistentItemDataHandler
    {
        IList<IBaseItem> GetAll(IList<IBaseItem> items);
        //bool SaveType();
        //bool UpdateType();
        //bool DeleteType();
    }
}
