using System.Collections.Generic;
using Model.BaseTypes;
using DataAccessLayer.DataHandlers;
using System.Collections.ObjectModel;

namespace DataAccessLayer
{
    public class CustomerRepository
    {
        public ObservableCollection<IBaseCustomer> Customers { get; set; }
        private CustomerRepository(IPersistentCustomerDataHandler cdh)
        {
            Customers = new ObservableCollection<IBaseCustomer>();
            Customers = cdh.GetAllCustomers();
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
