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
        private CustomerRepository()
        {
            Customers = new List<Customer>();
        }
        public void AddCustomer(Customer newCustomer)
        {
            Customers.Add(newCustomer);
        }
        private static CustomerRepository instance;

        public static CustomerRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new CustomerRepository();

            }
            return instance;
        }
    }

}
