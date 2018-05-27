using System.Collections.ObjectModel;
using DataAccessLayer;
using Model.BaseTypes;
using DataAccessLayer.DataHandlers;
using System.ComponentModel;
using System.Windows.Input;
using System;

namespace ViewModel
{
    public class ShowCustomersViewModel : AbstractNotifyPropertyChanged
    {
        private IPersistentCustomerDataHandler cDataHandler;
        private IBaseCustomer currentCustomer;
        private ICommand updateCustomer;

        public IBaseCustomer CurrentCustomer
        {
            get { return currentCustomer; }
            set
            {
                currentCustomer = value;
                CustomerName = currentCustomer.CustomerName;
                CVRNumber = currentCustomer.CVRNumber;
                CustomerAddress = currentCustomer.CustomerAddress;
                CustomerZip = currentCustomer.CustomerZip;
                CustomerCity = currentCustomer.CustomerCity;
                CustomerCountry = currentCustomer.CustomerCountry;
                CustomerDiscount = currentCustomer.CustomerDiscountPercent;
                CustomerEmail = currentCustomer.Email;
                CustomerPhoneNo = currentCustomer.PhoneNo;
                string[] propertiesChanged = {nameof(CustomerName), nameof(CVRNumber), nameof(CustomerAddress), nameof(CustomerZip),
                    nameof(CustomerCity), nameof(CustomerCountry), nameof(CustomerPhoneNo), nameof(CustomerEmail), nameof(CustomerDiscount) };
                NotifyPropertiesChanged(propertiesChanged);
            }
        }
        public ObservableCollection<IBaseCustomer> Customers
        {
            get { return cDataHandler.Customers; }
            set { cDataHandler.Customers = value; }
        }
        public string CustomerName { get; set; }
        public string CVRNumber { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerEmail { get; set; }
        public int CustomerZip { get; set; }
        public int CustomerPhoneNo { get; set; }
        public double CustomerDiscount { get; set; }
        public ICommand UpdateCustomer
        {
            get
            {
                if (updateCustomer == null)
                {
                    updateCustomer = new DelegateCommand(
                        param => UpdateCurrentCustomer(),
                        param => CanUpdateCustomer()
                    );
                }
                return updateCustomer;
            }
        }
        private void UpdateCurrentCustomer()
        {
            CurrentCustomer.CustomerName = CustomerName;
            CurrentCustomer.CustomerAddress = CustomerAddress;
            CurrentCustomer.CustomerDiscountPercent = CustomerDiscount;
            CurrentCustomer.CustomerZip = CustomerZip;
            CurrentCustomer.CustomerCity = CustomerCity;
            CurrentCustomer.PhoneNo = CustomerPhoneNo;
            CurrentCustomer.Email = CustomerEmail;
            CurrentCustomer.CustomerCountry = CustomerCountry;
            cDataHandler.SaveCustomer(CurrentCustomer);
        }
        private bool CanUpdateCustomer()
        {
            return true;
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
