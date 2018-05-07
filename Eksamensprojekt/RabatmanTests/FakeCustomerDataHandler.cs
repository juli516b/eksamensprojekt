using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

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
