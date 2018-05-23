using System.Windows;
using System.Windows.Input;
using ViewModel;
using DataAccessLayer; //Denne slettes - det er blot test. Husk at slette referencen også.

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
            ItemQueries IQ = new ItemQueries(); //Denne slettes - det er blot test.
            IQ.GetCurrentItems(); //Denne slettes - det er blot test.
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
