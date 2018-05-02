using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CustomerRepository
    {
        public IList<Customer> Customers { get; set; }
        public CustomerRepository()
        {
            Customers = new List<Customer>();
        }
        public void AddCustomer(Customer newCustomer)
        {
            Customers.Add(newCustomer);
        }
    }
}
