using System.Windows;
using System.Windows.Threading;

namespace Eksamensprojekt
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void Application_Dispatcher(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Kontakt Rabatman \n\n" + e.Exception.Message, "Hov! Der skete en fejl.", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }
    }
}
