using System.Collections.ObjectModel;
using DataAccessLayer;
using Model.BaseTypes;
using DataAccessLayer.DataHandlers;
using System.ComponentModel;
using System.Windows.Input;
using System;

namespace ViewModel
{
    public class ShowCustomersViewModel : INotifyPropertyChanged
    {
        private IPersistentCustomerDataHandler cDataHandler;
        private IBaseCustomer currentCustomer;
        private string customerName;
        private string customerAddress;
        private string customerCity;
        private string customerCountry;
        private string customerEmail;
        private int customerPhoneNo;
        private int customerZip;
        private double customerDiscount;
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

                NotifyPropertyChanged("CustomerName");
                NotifyPropertyChanged("CVRNumber");
                NotifyPropertyChanged("CustomerAddress");
                NotifyPropertyChanged("CustomerZip");
                NotifyPropertyChanged("CustomerCity");
                NotifyPropertyChanged("CustomerCountry");
                NotifyPropertyChanged("CustomerPhoneNo");
                NotifyPropertyChanged("CustomerEmail");
                NotifyPropertyChanged("CustomerDiscount");

            }
        }
        public ObservableCollection<IBaseCustomer> Customers
        {
            get { return cDataHandler.Customers; }
            set { cDataHandler.Customers = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        public string CVRNumber { get; set; }


        public string CustomerAddress
        {
            get { return customerAddress; }
            set { customerAddress = value; }
        }
        public string CustomerCity
        {
            get { return customerCity; }
            set { customerCity = value; }
        }
        public string CustomerCountry
        {
            get { return customerCountry; }
            set { customerCountry = value; }
        }
        public string CustomerEmail
        {
            get { return customerEmail; }
            set { customerEmail = value; }
        }
        public int CustomerZip
        {
            get { return customerZip; }
            set { customerZip = value; }
        }
        public int CustomerPhoneNo
        {
            get { return customerPhoneNo; }
            set { customerPhoneNo = value; }
        }
        public double CustomerDiscount
        {
            get { return customerDiscount; }
            set { customerDiscount = value; }
        }
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
            CurrentCustomer.CustomerName = customerName;
            CurrentCustomer.CustomerAddress = customerAddress;
            CurrentCustomer.CustomerDiscountPercent = customerDiscount;
            CurrentCustomer.CustomerZip = customerZip;
            CurrentCustomer.CustomerCity = customerCity;
            CurrentCustomer.PhoneNo = customerPhoneNo;
            CurrentCustomer.Email = customerEmail;
            CurrentCustomer.CustomerCountry = customerCountry;
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
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
