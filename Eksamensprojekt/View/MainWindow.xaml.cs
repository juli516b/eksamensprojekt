using System.Windows;
using System.Windows.Input;
using ViewModel;

namespace Eksamensprojekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        readonly OfferViewModel owm;
        public MainWindow()
        {
            owm = new OfferViewModel();
            InitializeComponent();
            DataContext = owm;
        }        
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
            
        }

        private void OnButtonClick_CreateCustomerWindow(object sender, RoutedEventArgs e)
        {
            new CreateCostumerWindow().Show();
        }
        private void OnButtonClick_ShowCustomersWindow(object sender, RoutedEventArgs e)
        {
            ShowCustomersWindow scw = new ShowCustomersWindow(owm);
            scw.Show();
        }
    }
}
