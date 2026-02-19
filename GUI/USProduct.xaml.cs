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
using MishnatYosef.Model;
using MishnatYosef.BLL;
namespace MishnatYosef.GUI
{
    /// <summary>
    /// Interaction logic for USProduct.xaml
    /// </summary>
    public partial class USProduct : UserControl
    {
        ProductInSale ps;
        ProductInBooking pb;
        Booking b;
        int num;
        public USProduct(ProductInSale p1,Booking b)
        {
            InitializeComponent();
            this.b = b;
            this.ps = p1;
            wrp1.DataContext = p1.Product;
            txtA.Text ="0";
            Ok.IsEnabled = false;
            img1.Source = MyPicture.GetImage(ps.Product.Picture);
            if (p1.AmountInStoke == 0)
            { 
                Ok.IsEnabled=false;
                Ok.Content = "אזל";
                Minus.IsEnabled=false;
                Plus.IsEnabled=false;
            }
        }
        public USProduct(ProductInBooking p1, Booking b)
        {
            InitializeComponent();
            this.b = b;
            this.pb = p1;
            this.ps = ProductInSaleService.GetList().FirstOrDefault(x => x.CodeProduct == p1.Product.Code);
            wrp1.DataContext = p1.Product;
            img1.Source = MyPicture.GetImage(ps.Product.Picture);
            num = pb.Amount;
            txtA.Text =pb.Amount.ToString();
            if (ps.AmountInStoke == 0)
            {
                Ok.Content = "אזל";
                Plus.IsEnabled = false;
            }
        }
        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            if (ps.AmountInStoke< int.Parse(txtA.Text))
            {
                MessageBox.Show("כמות זו אינה קימת במלאי");
            }
            else
            {
                Ok.IsEnabled = true;
                txtA.Text = (int.Parse(txtA.Text) + 1).ToString();
        
            }
        }
        private void Minus_Click(object sender, RoutedEventArgs e)
        {
           
            if (int.Parse(txtA.Text) == 0)
            {
                txtA.IsEnabled = false;
            }
            else
            {
                txtA.IsEnabled = true;
                txtA.Text = (int.Parse(txtA.Text) - 1).ToString();
                ps.AmountInStoke += 1;
                if (Ok.Content == "אזל")
                {
                    Ok.Content = "הוסף לסל";
                    Plus.IsEnabled = true;

                }
            }
           
        }
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (ps.AmountInStoke < int.Parse(txtA.Text))
            {
                MessageBox.Show("כמות זו אינה קימת במלאי");
            }
            else
            {
                MessageBox.Show("מוצר" + " " + ps.Product.NameProduct + " " + "כמות" + txtA.Text);
                if (ProductInBookingService.GetList().FirstOrDefault(x => x.Product.Code == ps.Product.Code && x.CodeBooking == b.Code&&x.C_Betaken_==true) == null)
                {
                    pb = new ProductInBooking();
                    pb.CodeBooking = b.Code;
                    pb.Product = ps.Product;
                    b.PaymentNumber = "1";
                    b.FinalAmount += int.Parse(txtA.Text) * ps.Product.Price;
                    pb.Booking = b;
                    ps.AmountInStoke -= int.Parse(txtA.Text);
                    pb.CodeProductInSale = ps.Product.Code;
                    pb.Amount = int.Parse(txtA.Text);
                    pb.C_Betaken_ = true;
                    b.ProductInBooking.Add(pb);
                    Globaly.UpdateDb();
                }
                else
                {
                    pb.Amount = int.Parse(txtA.Text);
                    ps.AmountInStoke -= pb.Amount;
                    ps.AmountInStoke+=num;
                    pb.C_Betaken_ = true;
                  
                    Globaly.UpdateDb();
                }
            }
        }
    }
}
