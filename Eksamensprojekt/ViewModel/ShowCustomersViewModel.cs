using System.Collections.ObjectModel;
using Model;
using Model.BaseTypes;

namespace ViewModel
{
    public class ShowCustomersViewModel
    {
        readonly IPersistentCustomerDataHandler cDataHandler;
        public IBaseCustomer CurrentCustomer { get; set; }
        public ObservableCollection<IBaseCustomer> Customers { get; set; }
        private readonly CustomerRepository customerRepo;
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
