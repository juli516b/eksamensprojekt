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
        OfferViewModel owm;
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
            CreateCostumerWindow cCW = new CreateCostumerWindow();
            cCW.Show();
        }
        private void OnButtonClick_ShowCustomersWindow(object sender, RoutedEventArgs e)
        {
            ShowCustomersWindow scw = new ShowCustomersWindow(owm);
            scw.Show();
        }
    }
}
