using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class ShowCustomersViewModel
    {
        public Customer CurrentCustomer { get; set; }
        public IList<Customer> Customers { get; set; }
        private CustomerRepository customerRepo;
        public ShowCustomersViewModel()
        {
            customerRepo = CustomerRepository.GetInstance();
            Customers = customerRepo.Customers;
            if (Customers.Count > 0)
            {
                CurrentCustomer = Customers[0];
            }
            
        }
    }
}
