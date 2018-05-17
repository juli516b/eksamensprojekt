using System.Collections.ObjectModel;
using Model;
using Model.BaseTypes;
using Model.DataHandlers;

namespace ViewModel
{
    public class ShowCustomersViewModel
    {
        public IBaseCustomer CurrentCustomer { get; set; }
        public ObservableCollection<IBaseCustomer> Customers { get; set; }

        public ShowCustomersViewModel()
        {
            IPersistentCustomerDataHandler cDataHandler = new CustomerDataHandler();
            CustomerRepository customerRepo = CustomerRepository.GetInstance(cDataHandler);
            Customers =new ObservableCollection<IBaseCustomer>(customerRepo.Customers);
            if (Customers.Count > 0)
            {
                CurrentCustomer = Customers[0];
            }
            
        }
    }
}
