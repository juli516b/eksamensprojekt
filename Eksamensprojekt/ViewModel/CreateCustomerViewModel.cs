using System.ComponentModel;
using System.Windows.Input;
using Model;
using DataAccessLayer;
using DataAccessLayer.DataHandlers;

namespace ViewModel
{
    public class CreateCustomerViewModel : INotifyPropertyChanged
    {
        private string customerMessage;
        private IPersistentCustomerDataHandler dataHandler;

        public CreateCustomerViewModel()
        {
            dataHandler = new DatabaseFacade();
        }
        public string CustomerMessage
        {
            get
            {
                return customerMessage;
            }
            set
            {
                customerMessage = value;
                NotifyPropertyChanged("CustomerMessage");
            }
        }
        private ICommand saveCustomer;
        private string customerName;
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand SaveCustomer
        {
            get
            {
                if (saveCustomer == null)
                {
                    saveCustomer = new DelegateCommand(
                        param => AddNewCustomer(),
                        param => CanAddCustomer()
                    );
                }
                return saveCustomer;
            }
        }

        private bool CanAddCustomer()
        {
            bool canExecute = CustomerName != "";
            return canExecute;
        }

        public void AddNewCustomer()
        {
            Customer myCustomer = new Customer
            {
                CustomerName = CustomerName,
                CustomerAddress = CustomerAdress,
                CustomerDiscount = CustomerDiscount,
                CustomerZip = CustomerZip,
                CustomerCity = CustomerCity,
                PhoneNo = PhoneNo,
                CVRNumber = CVRNumber,
                Email = Email,
                CustomerCountry = CustomerCountry
            };
            CustomerMessage = dataHandler.SaveCustomer(myCustomer);
        }

        public string CustomerName
        {
            get { return customerName; }
            set {
                customerName = value;
                NotifyPropertyChanged("CustomerName");
            }
        }
        public string CustomerCity { get; set; }
        public string CVRNumber { get; set; }
        public string CustomerAdress { get; set; }
        public int CustomerZip { get; set; }
        public int PhoneNo { get; set; }
        public string Email { get; set; }
        public double CustomerDiscount { get; set; }
        public string CustomerCountry { get; set; }
    }
}
