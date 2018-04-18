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


namespace Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = ViewModel.ViewModel.GetInstance();
            ViewModel.ViewModel.GetInstance().AddItem("Vare1", "1", 2);
            ViewModel.ViewModel.GetInstance().AddItem("Vare2", "2", 4);
            ViewModel.ViewModel.GetInstance().AddItem("Vare3", "3", 21);
            ViewModel.ViewModel.GetInstance().AddItem("Vare4", "4", 22);

        }
    }
}
