using System.Collections.Generic;
using Model.BaseTypes;

namespace DataAccessLayer.DataHandlers
{
    public interface IPersistentItemDataHandler
    {
        IList<IBaseItem> GetAll(IList<IBaseItem> items);
        //bool SaveType();
        //bool UpdateType();
        //bool DeleteType();
    }
}
