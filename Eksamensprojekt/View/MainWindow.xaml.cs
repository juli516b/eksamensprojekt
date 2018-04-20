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
        public MainWindow()
        {
            InitializeComponent();
            
            itemListView.DataContext= ViewModel.ItemViewModel.GetInstance;
            offerDataGrid.DataContext = ViewModel.OfferViewModel.GetInstance.ThisOffer.OfferLines;
            Price_Label.DataContext = ViewModel.OfferViewModel.GetInstance.ThisOffer; 
        }

        private void AddItem_Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Quantity_TextBox.Text, out int quantity))
            {
                ViewModel.OfferViewModel.GetInstance.AddOfferLine(ViewModel.OfferViewModel.GetInstance.ThisOffer, (Model.IItem)itemListView.SelectedItem, quantity);
                offerDataGrid.ItemsSource = null;
                offerDataGrid.ItemsSource = ViewModel.OfferViewModel.GetInstance.ThisOffer.OfferLines;
            }
            else
            {
                MessageBox.Show("Ugyldigt heltal. Indtast gyldigt heltal.");
            }
        }
    }
}
