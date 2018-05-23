using System.Collections.Generic;
using Model.BaseTypes;
using DataAccessLayer.DataHandlers;
using System.Collections.ObjectModel;

namespace RabatmanTests
{
    public class FakeCustomerDataHandler : IPersistentCustomerDataHandler
    {
        public ObservableCollection<IBaseCustomer> GetAllCustomers()
        {
            return new ObservableCollection<IBaseCustomer>();
        }

        public string SaveCustomer(IBaseCustomer newCustomer)
        {
            throw new System.NotImplementedException();
        }
    }
}
