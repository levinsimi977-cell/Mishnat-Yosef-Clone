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
    /// Interaction logic for MorePrToThisSale.xaml
    /// </summary>
    public partial class MorePrToThisSale : Page
    {
        Sale s;
        int code;
        List<ProductInSale> ls;
        public MorePrToThisSale()
        {
            InitializeComponent();
            DateTime dt = SaleService.GetList().Max(x => x.DateSale);      
            s = SaleService.GetList().FirstOrDefault(x => x.DateSale == dt);
            code = s.Code;
            ls = ProductInSaleService.GetList().Where(x => x.CodeSale == code).ToList();

            lstvP.ItemsSource=ls.ToList();
            
        }
        private void add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddExaitedPM(s));
        }
    }
}
