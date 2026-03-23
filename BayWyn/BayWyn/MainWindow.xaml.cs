using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BayWyn.View;

namespace BayWyn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (role == "Manager")
            {
                btnDelivery.Visibility = Visibility.Visible;
                btnCourier.Visibility = Visibility.Visible;
                btnReports.Visibility = Visibility.Visible;
            }

            if (role == "Admin")
            {
                btnDelivery.Visibility = Visibility.Visible;
                btnCourier.Visibility = Visibility.Visible;
                btnReports.Visibility = Visibility.Visible;

            }
            if (role == "Logistics Coordinator")
            {
                btnDelivery.Visibility = Visibility.Visible;
                btnCourier.Visibility = Visibility.Visible;
                btnReports.Visibility = Visibility.Collapsed;
            }
            if (role == "Courier")
            {
                btnDelivery.Visibility = Visibility.Collapsed;
                btnCourier.Visibility = Visibility.Visible;
                btnReports.Visibility = Visibility.Collapsed;
            }
        }
    }
}