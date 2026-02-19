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
using MishnatYosef.Model;

namespace MishnatYosef.GUI
{
    /// <summary>
    /// Interaction logic for BookingCPage.xaml
    /// </summary>
    public partial class BookingCPage : Page
    {
        int code;
        public BookingCPage()
        {
            InitializeComponent();
            if (BookingService.GetList().Where(x => x.Client.ClientId == Globaly.UserId).ToList().Count==0)
            {
                MessageBox.Show("אין לך הזמנות");
                stp.Visibility = Visibility.Hidden;
            }
            else
            {
                lstv.ItemsSource = BookingService.GetList().Where(x => x.Client.ClientId == Globaly.UserId).ToList();

                if (BookingService.GetList().Where(x => x.Client.ClientId == Globaly.UserId).Max(x => x.Sale.DateSale)<DateTime.Today)
                {
                    change.Visibility = Visibility.Hidden;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
          int da= BookingService.GetList().Where(x => x.Client.ClientId == Globaly.UserId).Max(x => x.Code);
           Booking b= BookingService.GetList().Where(x => x.Client.ClientId == Globaly.UserId).FirstOrDefault(x=>x.Code== da);
            List<ProductInBooking> pb=b.ProductInBooking.ToList();
            NavigationService.Navigate(new OrderProductC(pb,b));
        }
      

        private void lstv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            code=(lstv.SelectedItem as Booking).Code;
            txtp.Text = "הזמנה מספר" + code.ToString();/*" "+"הזמנה מספר";*/
            stpP.Visibility = Visibility.Visible;
            Booking b = BookingService.GetList().FirstOrDefault(x => x.Code == code);
            lstvp.ItemsSource = b.ProductInBooking.Where(x=>x.C_Betaken_==true).ToList();
            lstvp.DataContext = b.ProductInBooking.Where(x => x.C_Betaken_ == true).ToList();
        }
    }
}