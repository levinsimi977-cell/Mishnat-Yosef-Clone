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
    /// Interaction logic for LessProduct.xaml
    /// </summary>
    public partial class LessProduct : Page
    {
        Sale s;
        public LessProduct()
        {
            InitializeComponent();
         
            DateTime date = SaleService.GetList().Max(x => x.DateSale);
            lstv.ItemsSource=ProductInSaleService.GetList().Where(x=>x.Sale.DateSale==date).ToList();
            s=SaleService.GetList().FirstOrDefault(x=>x.DateSale==date);
           
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
          
            if(lstv.SelectedItems.Count > 0)
            { 
            s.ProductInSale.Remove(lstv.SelectedItem as ProductInSale);
            Globaly.UpdateDb();
            lstv.ItemsSource = null;
            lstv.ItemsSource =ProductInSaleService.GetList().Where(x => x.CodeSale== s.Code).ToList();
            MessageBox.Show("הוסר");
            }
        }

    }
}

