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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;


namespace Eksamensprojekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OfferViewModel offerViewModel;
        public MainWindow()
        {
            InitializeComponent();
            offerViewModel = new OfferViewModel();
            DataContext = offerViewModel;
        }
        
        private void AddItem_Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Quantity_TextBox.Text, out int quantity))
            {
                offerViewModel.AddOfferLine(offerViewModel.ThisOffer, (Model.IBaseItem)itemListView.SelectedItem, quantity);
                offerDataGrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Ugyldigt heltal. Indtast gyldigt heltal.");
            }
        }
        private void OfferDataGrid_CellValueChanged(object sender, DataGridCellEditEndingEventArgs e)
        {
            offerViewModel.UpdateOfferTotal();
        }
        private void OfferDiscount_TextBoxValueChanged(object sender, TextChangedEventArgs e)
        {
            offerViewModel.UpdateOfferTotal();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
        }
    }
}
