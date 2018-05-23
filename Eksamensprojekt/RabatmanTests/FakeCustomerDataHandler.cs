using System.Collections.Generic;
using Model.BaseTypes;
using DataAccessLayer.DataHandlers;

namespace RabatmanTests
{
    public class FakeCustomerDataHandler : IPersistentCustomerDataHandler
    {
        public IList<IBaseCustomer> GetAll(IList<IBaseCustomer> customers)
        {
            return customers;
        }
    }
}
