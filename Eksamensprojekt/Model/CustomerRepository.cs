using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CustomerRepository
    {
        IPersistentCustomerDataHandler cDataHandler;
        public IList<IBaseCustomer> Customers { get; set; }
        private CustomerRepository(IPersistentCustomerDataHandler cdh)
        {
            cDataHandler = cdh;
            Customers = new List<IBaseCustomer>();
            Customers = cdh.GetAll(Customers);
        }
        public string AddCustomer(IBaseCustomer newCustomer) 
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
        public static CustomerRepository GetInstance(IPersistentCustomerDataHandler cdh)
        {
            if (instance == null)
            {
                instance = new CustomerRepository(cdh);
            }
            return instance;
        }
    }

}
