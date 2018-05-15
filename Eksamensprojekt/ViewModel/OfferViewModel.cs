using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Model;


namespace ViewModel
{
    public class OfferViewModel : INotifyPropertyChanged
    {
        IPersistentItemDataHandler dataHandler;
        private ICommand clickAddButtonCommand;
        private Offer currentOffer;

        public Customer MyCustomer
        {
            get
            {
                Customer customer = new Customer() { CustomerName = "Ingen kunde valgt. Klik for at tilføje" };
                if (currentOffer.MyCustomer != null)
                {
                    customer = currentOffer.MyCustomer;
                }
                return customer;
            }
            set
            {
                currentOffer.MyCustomer = value;
                NotifyPropertyChanged("MyCustomer");
                NotifyPropertyChanged("OfferTotal");
                NotifyPropertyChanged("MyCustomerDiscount");
            }
        }
        public double OfferLinesSubtotal
        {
            get { return OfferLines.Sum(offerLine => offerLine.Item.ItemPrice * offerLine.Quantity); }
        }
        public string MyCustomerDiscount
        {
            get
            {
                string customerDiscount_Label = "";
                if (MyCustomer != null)
                {
                    customerDiscount_Label = MyCustomer.CustomerDiscount.ToString() + " %";
                }
                return customerDiscount_Label;
            }
        }
        public double  ForwardingAgentPrice
        {
            get { return currentOffer.ForwardingAgentPrice; }
            set {
                currentOffer.ForwardingAgentPrice = value;
                NotifyPropertyChanged("OfferTotal");
            }
        }
        public IBaseItem SelectedItem { get; set; }
        public string QuantityTextBoxText { get; set; }

        public ICommand AddButtonCommand
        {
            get
            {
                if (clickAddButtonCommand == null)
                {
                    clickAddButtonCommand = new DelegateCommand(
                        param => this.AddItem(),
                        param => this.CanAdd()
                    );
                }
                return clickAddButtonCommand;
            }
        }

        private bool CanAdd()
        {
            if(SelectedItem != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AddItem()
        {
            if (SelectedItem != null)
            {
                if (int.TryParse(QuantityTextBoxText, out int quantity))
                {
                   AddOfferLine((Model.IBaseItem)SelectedItem, quantity);
                    
                }
                else
                {
                    MessageBox.Show("Ugyldigt heltal. Indtast gyldigt heltal.");
                }
            }
            else
            {
                MessageBox.Show("Du skal vælge en vare fra listen.");
            }
        }

        public IList<IBaseItem> Items {
            get { return ItemRepository.GetInstance(dataHandler).Items; }
            set { ItemRepository.GetInstance(dataHandler).Items = value; }
        }
        public string OfferDiscount
        {
            get { return Math.Round(currentOffer.OfferDiscount,2).ToString(); }
            set
            {
                if (value == null || value == "")
                {
                    currentOffer.OfferDiscount = 0;

                }
                else { 
                    currentOffer.OfferDiscount = Convert.ToDouble(value);
                }
                NotifyPropertyChanged("OfferTotal");
            }
        }
        public ObservableCollection<OfferLine> OfferLines
        {
            get { return currentOffer.OfferLines; }
            set { currentOffer.OfferLines = value; }
        }

        public double OfferTotal {
            get { return Math.Round(currentOffer.OfferTotal,2); }
        }
        public int NoOfTotalPallets
        {
            get
            {
                return OfferLines.Sum(offerLine => offerLine.NoOfPallets);
            }
        }
        public int NoOfTotalPackages
        {
            get
            {
                return OfferLines.Sum(offerLine => offerLine.NoOfPackages);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public OfferViewModel()
        {
            dataHandler = new ItemDataHandler();
            currentOffer = new Offer(DateTime.Now);
            SelectedItem = Items[0];
        }
        public void AddOfferLine(IBaseItem myItem, int quantity)
        {
            OfferLine newOfferLine = new OfferLine(myItem, quantity);
            OfferLines.Add(newOfferLine);
            newOfferLine.APWC += NotifyPropertyChanged;
            NotifyPropertyChanged("OfferTotal");
            NotifyPropertyChanged("NoOfTotalPackages");
            NotifyPropertyChanged("NoOfTotalPallets");
            NotifyPropertyChanged("OfferLinesSubtotal");
        }
    }
}
