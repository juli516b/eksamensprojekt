using System.Collections.Generic;
using System.Collections.ObjectModel;
using Model.BaseTypes;

namespace DataAccessLayer.DataHandlers
{
    public interface IPersistentCustomerDataHandler
    {
        ObservableCollection<IBaseCustomer> Customers { get; set; }
        ObservableCollection<IBaseCustomer> GetAllCustomers();
        IBaseCustomer SaveCustomer(IBaseCustomer newCustomer);
    }
}

