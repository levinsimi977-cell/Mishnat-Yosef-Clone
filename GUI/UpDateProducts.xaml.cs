using MishnatYosef.BLL;
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
namespace MishnatYosef.GUI
{
    /// <summary>
    /// Interaction logic for UpDateProducts.xaml
    /// </summary>
    public partial class UpDateProducts : Page
    {
        List<ProductInSale> ls;
        ProductInSale ps;
        Sale sale,sc;
        public UpDateProducts(Sale sale)
        {
            InitializeComponent();
            lstL.DataContext = SaleService.GetList().Where(X=>X.ProductInSale.Count()>1);
            lstL.ItemsSource = SaleService.GetList().Where(X => X.ProductInSale.Count() > 1);
            this.sale = sale;
          sc = new Sale();
        }

        private void UpDate_Click(object sender, RoutedEventArgs e)
        {
            if (Validation.GetHasError(amount2) )
                MessageBox.Show("יש שגיאה בנתונים");
            else
            {
                if (lstv.SelectedItems.Count == 1)
                {
                    ps = lstv.SelectedItem as ProductInSale;
                    ps.AmountInStoke = int.Parse(amount2.Text);
                    Globaly.UpdateDb();
                    MessageBox.Show("המוצר הועדכן");
                    lstv.ItemsSource =null;

                    lstv.ItemsSource = ls;

                }
            }
        }
        private void lstL_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            sc = lstL.SelectedItem as Sale;
            ls = ProductInSaleService.GetList().Where(x => x.Sale == sc).ToList();
            foreach (ProductInSale item in ls)
            { 
                sale.ProductInSale.Add(item);
                Globaly.UpdateDb();   
            }
            MessageBox.Show("רשימה זו התוספה בהצלחה" +
                ",באפשרותך להוסיף עוד מוצרים בודדים");
            Globaly.UpdateDb();
            stp1.Visibility=Visibility.Hidden;
            stp2.Visibility=Visibility.Visible;
            lstv.ItemsSource = null;
            lstv.ItemsSource = ls;
            wrp.Visibility=Visibility.Visible;
        }           

    }
}
