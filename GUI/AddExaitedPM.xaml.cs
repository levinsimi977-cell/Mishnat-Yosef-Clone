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
    /// Interaction logic for AddExaitedPM.xaml
    /// </summary>
    public partial class AddExaitedPM : Page
    {
        ProductInSale ps,p2;
        Product p;
        Sale Sale;
        public AddExaitedPM(Sale sale)
        {
            InitializeComponent();
            lstvP.ItemsSource=ProductService.GetList(); 
            this.Sale = sale;
            ps= new ProductInSale();
        }  
        private void lett_Click(object sender, RoutedEventArgs e)
        {

            if (Validation.GetHasError(a1))
                MessageBox.Show("יש שגיאה בנתונים");
         
            else
            { 
               if (lstvP.SelectedItems.Count == 1)
              {
                    p = lstvP.SelectedItem as Product;
                    ps.Product = p;
                    ps.Sale =this.Sale;
                    ps.AmountInStoke = int.Parse(a1.Text);
                    p2 = this.Sale.ProductInSale.FirstOrDefault(x => x.Product == p);
                    if( p2== null)
                    {
                    Sale.ProductInSale.Add(ps);
                    Globaly.UpdateDb();
                    MessageBox.Show("התוסף");
                        lstvP.ItemsSource = null;
                        lstvP.ItemsSource =ProductService.GetList();
                    }
                    else
                    MessageBox.Show("מוצר זה כבר קיים");
               
              }        
            }
        }
       
    }
}