using System.Collections.Generic;
using Model;
using Model.BaseTypes;

namespace RabatManCustomerTest
{
    public class FakeCustomerDataHandler : IPersistentCustomerDataHandler
    {
        public IList<IBaseCustomer> GetAll(IList<IBaseCustomer> customers)
        {
            return customers;
        }
    }
}
