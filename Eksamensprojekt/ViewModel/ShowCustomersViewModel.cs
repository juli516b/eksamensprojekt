using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class ShowCustomersViewModel
    {
        IPersistentCustomerDataHandler cDataHandler;
        public IBaseCustomer CurrentCustomer { get; set; }
        public ObservableCollection<IBaseCustomer> Customers { get; set; }
        private CustomerRepository customerRepo;
        public ShowCustomersViewModel()
        {
            cDataHandler = new CustomerDataHandler();
            customerRepo = CustomerRepository.GetInstance(cDataHandler);
            Customers =new ObservableCollection<IBaseCustomer>(customerRepo.Customers);
            if (Customers.Count > 0)
            {
                CurrentCustomer = Customers[0];
            }
            
        }
    }
}
