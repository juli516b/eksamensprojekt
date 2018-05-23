using System.Collections.Generic;
using System.Collections.ObjectModel;
using Model.BaseTypes;

namespace DataAccessLayer.DataHandlers
{
    public interface IPersistentCustomerDataHandler
    {
        ObservableCollection<IBaseCustomer> GetAllCustomers();
        string SaveCustomer(IBaseCustomer newCustomer);
        //bool SaveType();
        //bool UpdateType();
        //bool DeleteType();
    }
}

