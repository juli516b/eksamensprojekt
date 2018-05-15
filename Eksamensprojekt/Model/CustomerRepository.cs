using System.Collections.Generic;
using Model.BaseTypes;

namespace Model
{
    public class CustomerRepository
    {
        public IList<IBaseCustomer> Customers { get; private set; }
        private CustomerRepository(IPersistentCustomerDataHandler cdh)
        {
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
