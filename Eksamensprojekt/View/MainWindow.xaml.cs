﻿using System;
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
        
        //private void AddItem_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    if (itemListView.SelectedItem != null)
        //    {
        //        if (int.TryParse(Quantity_TextBox.Text, out int quantity))
        //        {
        //            offerViewModel.AddOfferLine((Model.IBaseItem)itemListView.SelectedItem, quantity);
        //            offerDataGrid.Items.Refresh();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Ugyldigt heltal. Indtast gyldigt heltal.");
        //        }
        //    }
        //    else {
        //        MessageBox.Show("Du skal vælge en vare fra listen.");
        //    }
        //}
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
            
        }

    //    private void AddItem_Button_Click(object sender, RoutedEventArgs e)
    //    {
    //        if (itemListView.SelectedItem != null)
    //        {
    //            if (int.TryParse(Quantity_TextBox.Text, out int quantity))
    //            {
    //                offerViewModel.AddOfferLine((Model.IBaseItem)itemListView.SelectedItem, quantity);
    //            }
    //            else
    //            {
    //                MessageBox.Show("Ugyldigt heltal. Indtast gyldigt heltal.");
    //            }
    //        }
    //        else
    //        {
    //            MessageBox.Show("Du skal vælge en vare fra listen.");
    //        }
    //    }
    }
}
