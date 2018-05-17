using System.Windows;
using Model;
using ViewModel;

namespace Eksamensprojekt
{
    /// <summary>
    /// Interaction logic for ShowCustomersWindow.xaml
    /// </summary>
    public partial class ShowCustomersWindow
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

        //Ny Mathias
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            owm.MyCustomer = (Customer)CustomerListView.SelectedItem;
            Close_window_click(sender, e);
        }

        private void Close_window_click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddCustomer_click(object sender, RoutedEventArgs e)
        {
            CreateCostumerWindow cCW = new CreateCostumerWindow();
            cCW.Show();
            Close_window_click(sender, e);
        }
    }
}
