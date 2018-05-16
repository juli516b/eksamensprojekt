using System.Collections.Generic;
using Model.BaseTypes;
using Model.DataHandlers;

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
