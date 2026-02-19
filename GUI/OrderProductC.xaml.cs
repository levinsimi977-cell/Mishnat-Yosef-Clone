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
    /// Interaction logic for OrderProductC.xaml
    /// </summary>
    public partial class OrderProductC : Page
    {
        ProductInSale ps2;
        ProductInBooking p;
        DateTime date1;
        List<ProductInBooking> bp;
        Booking pb;
        List<ProductInSale> ps;
        int max=0;
        double sum = 0.0;
        public OrderProductC()
        {        
            InitializeComponent();

            pb = new Booking();

            //רק את המכירה של השבוע הנוכחי
            if (SaleService.GetList().Count>0)
            {

                DateTime date = SaleService.GetList().Max(x => x.DateSale);
                ps =ProductInSaleService.GetList().Where(x => x.Sale.DateSale == date).Distinct().ToList();
                pb.CodeSale = SaleService.GetList().FirstOrDefault(x => x.DateSale == date).Code;
                pb.CodeClient = ClientServise.GetList().FirstOrDefault(x => x.ClientId == Globaly.UserId).ClientId;
                pb.Client = ClientServise.GetList().FirstOrDefault(x => x.ClientId == Globaly.UserId);
                pb.Sale = SaleService.GetList().FirstOrDefault(x => x.DateSale == date);
                Globaly.UpdateDb();
                BookingService.Add(pb);

                foreach (var item in ps)
                {
                    USProduct u = new USProduct(item, pb);
                    u.Margin = new Thickness(5, 5, 5, 5);
                    wrp.Children.Add(u);
                }
            }
            cmbK.DataContext = CategoryService.GetList();
            cmbK.ItemsSource = CategoryService.GetList();
            cmbM.DataContext = ProductTrandService.GetList();
            cmbM.ItemsSource = ProductTrandService.GetList();
            lb1.ItemsSource = ProductInBookingService.GetList().Where(x => x.Booking.Code == pb.Code).ToList();
            lb1.DataContext = ProductInBookingService.GetList().Where(x => x.Booking.Code == pb.Code).ToList();

        }
        public OrderProductC(List<ProductInBooking> ps, Booking b)
        {
            InitializeComponent();
            bp = (List<ProductInBooking>)ps.Where(x=>x.C_Betaken_==true).Distinct().ToList();
            pb = b;
            foreach (var item in bp)
            {

                USProduct u = new USProduct(item, pb);
                u.Margin = new Thickness(5, 5, 5, 5);
                wrp.Children.Add(u);
                
            }
            date1 = SaleService.GetList().Max(x => x.DateSale);
            this.ps=ProductInSaleService.GetList().Where(x => x.Sale.DateSale==date1).ToList().Where(x=>bp.Any(y=>y.Product.Code==x.CodeProduct)==false).ToList();
            foreach (var item in this.ps)
            {
                USProduct u = new USProduct(item, pb);
                u.Margin = new Thickness(5, 5, 5, 5);
                wrp.Children.Add(u);
            }
           cmbK.IsEnabled=false;
            cmbM.IsEnabled=false;
            all.IsEnabled = false;
            //lb1.ItemsSource = ProductInBookingService.GetList().Where(x => x.CodeBooking == pb.Code).ToList();
            //lb1.DataContext = ProductInBookingService.GetList().Where(x => x.CodeBooking == pb.Code).ToList();

        }
        private void cmbK_SelectionChanged(object sender, SelectionChangedEventArgs e)      
        {
            date1 = SaleService.GetList().Max(x => x.DateSale);
            ps = ProductInSaleService.GetList().Where(x => x.Sale.DateSale == date1).ToList().Where(x => x.Product.Category == (Category)cmbK.SelectedItem).ToList();
            wrp.Children.Clear();
            foreach (var item in this.ps)
            {
                USProduct u = new USProduct(item, pb);
                u.Margin = new Thickness(5, 5, 5, 5);
                wrp.Children.Add(u);
            }
        }

        private void cmbM_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            date1 = SaleService.GetList().Max(x => x.DateSale);
            ps = ProductInSaleService.GetList().Where(x => x.Sale.DateSale == date1).ToList().Where(x => x.Product.ProductTrand == (ProductTrand)cmbM.SelectedItem).ToList();
            wrp.Children.Clear();
            foreach (var item in this.ps)
            {
                USProduct u = new USProduct(item, pb);
                u.Margin = new Thickness(5, 5, 5, 5);
                wrp.Children.Add(u);
            }
        }
        private void see_Click(object sender, RoutedEventArgs e)
        {
            lb1.DataContext = null;
            lb1.ItemsSource = ProductInBookingService.GetList().Where(x => x.Booking.Code == pb.Code && x.C_Betaken_ == true).ToList();
            lb1.DataContext = ProductInBookingService.GetList().Where(x => x.Booking.Code == pb.Code && x.C_Betaken_ == true).ToList();

        }

        private void lett_Click(object sender, RoutedEventArgs e)
        {
          sum = 0;
          if(BookingService.GetList().Where(x => x.Client.ClientId == Globaly.UserId).ToList().Count>0)
          {           
            max = BookingService.GetList().Where(x => x.Client.ClientId == Globaly.UserId).Max(x => x.Code);
            bp = BookingService.GetList().Where(x => x.Client.ClientId == Globaly.UserId).FirstOrDefault(x => x.Code == max).ProductInBooking.ToList();
            foreach (var productInBooking in this.bp)
            {
                sum += (productInBooking.Amount) * productInBooking.Product.Price;
            }
            MessageBox.Show(sum + " :סכום הקניה ");
        
                bp = ProductInBookingService.GetList().Where(x => x.Booking.Client.ClientId == Globaly.UserId).ToList();
                max = bp.Max(x => x.CodeBooking);
                pb = bp.FirstOrDefault(x => x.CodeBooking == max).Booking;
                pb.FinalAmount = sum;
                MessageBox.Show(".רכישתך התבצעה בהצלחה");
             
          }
          else
            MessageBox.Show("לא קימת הזמנה");
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            p= (sender as Button).DataContext as ProductInBooking;
            p.C_Betaken_ = false;
            Globaly.UpdateDb();
            lb1.ItemsSource = null;
            lb1.ItemsSource = ProductInBookingService.GetList().Where(x => x.CodeBooking ==pb.Code&&x.C_Betaken_==true).ToList();
            lb1.DataContext = ProductInBookingService.GetList().Where(x => x.CodeBooking ==pb.Code &&x.C_Betaken_== true).ToList();
            max = SaleService.GetList().Max(x => x.Code);
            ps2 = ProductInSaleService.GetList().FirstOrDefault(x => x.Product.Code == p.Product.Code&&x.CodeSale==max);
            ps2.AmountInStoke += p.Amount;
            p.Amount = 0;
            Globaly.UpdateDb();

        }

        private void all_Click(object sender, RoutedEventArgs e)
        {
            date1 = SaleService.GetList().Max(x => x.DateSale);
            ps = ProductInSaleService.GetList().Where(x => x.Sale.DateSale == date1).ToList();
            wrp.Children.Clear();
            foreach (var item in this.ps)
            {
                USProduct u = new USProduct(item, pb);
                u.Margin = new Thickness(5, 5, 5, 5);
                wrp.Children.Add(u);
            }
        }
    }
}
