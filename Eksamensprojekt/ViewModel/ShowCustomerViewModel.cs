using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class ShowCustomerViewModel
    {
        public Customer CurrentCustomer { get; set; }
        public IList<Customer> Customers { get; set; }
        private CustomerRepository customerRepo;
        public ShowCustomerViewModel()
        {
            customerRepo = CustomerRepository.GetInstance();
            Customers = customerRepo.Customers;
            if (Customers.Count == 0)
            {
                Customer hest = new Customer()
                {
                    CustomerName = "Der er endnu ingen kunder i listen",
                    CVRNumber = "666"
                };
                Customer ko = new Customer()
                {
                    CustomerName = "Her er en mere",
                    CVRNumber = "69"
                };
                Customers.Add(hest);
                Customers.Add(ko);
            }
            CurrentCustomer = Customers[0];
        }
    }
}
