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
    /// Interaction logic for AllSale.xaml
    /// </summary>
    public partial class AllSale : Page
    {
        List<ProductInSale> ls;
       int code;
        Sale sale;
        public AllSale( Sale sale)
        {
            InitializeComponent();
            lstv.ItemsSource = SaleService.GetList();
            this.sale=sale; 
        }

        private void lstv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {        
            code=(lstv.SelectedItems as Sale).Code;  
            ls =ProductInSaleService.GetList().Where(x => x.CodeSale==code).ToList();
            foreach (var item in ProductInSaleService.GetList())
            {
                sale.ProductInSale.Add(item);
            }
            MessageBox.Show("רשימה זו התוספה בהצלחה,באפשרותך להוסיף עוד רשימה");
            Globaly.UpdateDb();
        }
    }
}
