using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ViewModel;
using Model;

namespace Eksamensprojekt
{
    /// <summary>
    /// Interaction logic for ShowCustomersWindow.xaml
    /// </summary>
    public partial class ShowCustomersWindow : Window
    {
        private OfferViewModel owm;
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
            this.Close();
        }

        private void AddCustomer_click(object sender, RoutedEventArgs e)
        {
            CreateCostumerWindow cCW = new CreateCostumerWindow();
            cCW.Show();
            Close_window_click(sender, e);
        }
    }
}
