using System.Collections.Generic;
using Model.BaseTypes;

namespace DataAccessLayer.DataHandlers
{
    public interface IPersistentCustomerDataHandler
    {
        IList<IBaseCustomer> GetAll(IList<IBaseCustomer> customers);
        //bool SaveType();
        //bool UpdateType();
        //bool DeleteType();
    }
}

