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
using MishnatYosef.BLL;
namespace MishnatYosef.GUI
{
    /// <summary>
    /// Interaction logic for SeeBooking.xaml
    /// </summary>
    public partial class SeeBooking : Page
    {
        public SeeBooking()
        {
            InitializeComponent();
            if (SaleService.GetList().Count > 0)
            {
                DateTime date = SaleService.GetList().Max(x => x.DateSale);
                lstv.ItemsSource = BookingService.GetList().Where(x => x.Sale.DateSale == date);
            }
           
        }
    }
}
