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
using System.Windows.Shapes;
using MishnatYosef.Model;
using MishnatYosef.BLL;

namespace MishnatYosef.GUI
{
    /// <summary>
    /// Interaction logic for ManegerPage.xaml
    /// </summary>
    public partial class ManegerPage : Window
    {
        public ManegerPage()
        {
            InitializeComponent();
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            mFrame.Navigate(new AddSale());
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = SaleService.GetList().Max(x => x.DateSale);
            Sale sale= SaleService.GetList().FirstOrDefault(x => x.DateSale == date);
            mFrame.Navigate(new AddExaitedPM(sale));
        }

     

    
        private void AP_Click(object sender, RoutedEventArgs e)
        {
            mFrame.Navigate(new AddProduct());

        }

        private void AT_Click(object sender, RoutedEventArgs e)
        {
            mFrame.Navigate(new AddTrand());

        }

        //private void AB_Click(object sender, RoutedEventArgs e)
        //{
        //    mFrame.Navigate(new AddBranch());

        //}

        private void ACa_Click(object sender, RoutedEventArgs e)
        {
            mFrame.Navigate(new AddCategory());

        }

        private void ACi_Click(object sender, RoutedEventArgs e)
        {
            mFrame.Navigate(new AddCity());

        }

        private void see_Click(object sender, RoutedEventArgs e)
        {
            mFrame.Navigate(new SeeBooking());

        }

        private void Ab_Click(object sender, RoutedEventArgs e)
        {
            mFrame.Navigate(new AddBranch());

        }

        private void more_Click(object sender, RoutedEventArgs e)
        {
            mFrame.Navigate(new MorePrToThisSale());
        }
    }
}
