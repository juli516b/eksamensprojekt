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
        public string AddCustomer(Customer newCustomer) 
        {
            string message = "Kunden blev ikke \ntilføjet til kundelisten";
            Customers.Add(newCustomer);
            if (Customers.Contains(newCustomer))
            {
                message = "Kunden blev \ntilføjet til kundelisten.";
            }
            return message;
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
