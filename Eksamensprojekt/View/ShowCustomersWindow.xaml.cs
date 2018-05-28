using System.Windows;
using Model;
using ViewModel;

namespace Eksamensprojekt
{
    /// <summary>
    /// Interaction logic for ShowCustomersWindow.xaml
    /// </summary>
    public partial class ShowCustomersWindow:Window
    {
        private readonly OfferViewModel owm;
        public ShowCustomersWindow()
        {
            InitializeComponent();
        }
        public ShowCustomersWindow(OfferViewModel owm)
        {
            InitializeComponent();
            this.owm = owm;
        }

        private void AddCustomerToOffer_Click(object sender, RoutedEventArgs e)
        {
            owm.AddCustomer((Customer)CustomerListView.SelectedItem);
            //owm.MyCustomer = (Customer)CustomerListView.SelectedItem;
            Close_Window_Click(sender, e);
        }

        private void Close_Window_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            CreateCostumerWindow cCW = new CreateCostumerWindow();
            cCW.Show();
            Close_Window_Click(sender, e);
        }
    }
}
