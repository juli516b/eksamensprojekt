using System.Collections.ObjectModel;
using DataAccessLayer;
using Model.BaseTypes;
using DataAccessLayer.DataHandlers;

namespace ViewModel
{
    public class ShowCustomersViewModel
    {
        private IPersistentCustomerDataHandler cDataHandler;
        public IBaseCustomer CurrentCustomer { get; set; }
        public ObservableCollection<IBaseCustomer> Customers
        {
            get { return CustomerRepository.GetInstance(cDataHandler).Customers; }
            set { CustomerRepository.GetInstance(cDataHandler).Customers = value; }

        } 

        public ShowCustomersViewModel()
        {
            cDataHandler = new DatabaseFacade();
            CustomerRepository customerRepo = CustomerRepository.GetInstance(cDataHandler);
            Customers =new ObservableCollection<IBaseCustomer>(customerRepo.Customers);
            if (Customers.Count > 0)
            {
                CurrentCustomer = Customers[0];
            }
            
        }
    }
}
