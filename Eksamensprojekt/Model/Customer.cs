using Model.BaseTypes;
using System.ComponentModel;

namespace Model
{
    public class Customer : IBaseCustomer, INotifyPropertyChanged
    {
        private string customerName;
        private int phoneNo;
        public event PropertyChangedEventHandler PropertyChanged;
        public int CustomerId { get; set; }
        public string CustomerName
        {
            get { return customerName; }
            set
            {
                customerName = value;
                NotifyPropertyChanged("CustomerName");
            }
        }
        public string CVRNumber { get; set; }
        public string CustomerAddress { get; set; }
        public int CustomerZip { get; set; }
        public string CustomerCity { get; set; }
        public int PhoneNo
        {
            get { return phoneNo; }
            set {
                phoneNo = value;
                NotifyPropertyChanged("PhoneNo");
            }
        }
        public string Email { get; set; }
        public double CustomerDiscountPercent { get; set; }
        public string CustomerCountry { get; set; }
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
