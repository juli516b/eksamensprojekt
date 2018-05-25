using System.Collections.Generic;
using Model.BaseTypes;
using DataAccessLayer.DataHandlers;
using System.Collections.ObjectModel;

namespace RabatmanTests
{
    public class FakeCustomerDataHandler : IPersistentCustomerDataHandler
    {
        public ObservableCollection<IBaseCustomer> Customers { get; set; }

        public ObservableCollection<IBaseCustomer> GetAllCustomers()
        {
            return new ObservableCollection<IBaseCustomer>();
        }

        IBaseCustomer IPersistentCustomerDataHandler.SaveCustomer(IBaseCustomer newCustomer)
        {
            Customers.Add(newCustomer);
            return newCustomer;
        }
    }
}
