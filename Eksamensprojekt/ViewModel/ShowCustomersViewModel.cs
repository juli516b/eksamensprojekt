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
            get { return cDataHandler.Customers; }
            set { cDataHandler.Customers = value; }
        } 

        public ShowCustomersViewModel()
        {
            cDataHandler = new DatabaseFacade();
            Customers = cDataHandler.GetAllCustomers();
            if (Customers.Count > 0)
            {
                CurrentCustomer = Customers[0];
            }
            
        }
    }
}
