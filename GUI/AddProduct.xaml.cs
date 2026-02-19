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
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Page
    {
        string s;
        Product p,p2;
        public AddProduct()
        {      
            InitializeComponent();
            p = new Product();
            stp.DataContext=p;
            cmbC.ItemsSource = CategoryService.GetList();
            cmbC.DataContext = CategoryService.GetList();
            cmbM.ItemsSource = ProductTrandService.GetList();           
            cmbM.DataContext = ProductTrandService.GetList();
            stp.DataContext = p;  
            lstvP.ItemsSource = ProductService.GetList();
        }
        private void addPicture_Click(object sender, RoutedEventArgs e)
        {
            s= MyPicture.LoadingImg();
            p.Picture = s;
        }
        private void lett_Click(object sender, RoutedEventArgs e)
        {

            if (Validation.GetHasError(nameP)|| Validation.GetHasError(Pprice))
                MessageBox.Show("יש שגיאה בנתונים");
           
            else if (nameP.Text.Length < 2)
                MessageBox.Show("הנתונים לא הוכנסו כראוי");
            else {
            p.Category= cmbC.SelectedItem as Category;
            p.ProductTrand=cmbM.SelectedItem as ProductTrand;
            p2 = ProductService.GetList().FirstOrDefault(x => x.NameProduct == p.NameProduct);

            if (p2== null)
            {
                ProductService.Add(p);
                Globaly.UpdateDb();
                MessageBox.Show("התוסף בהצלחה");
                    lstvP.ItemsSource = null;
                    lstvP.ItemsSource =ProductService.GetList();
                }
            else
                MessageBox.Show("מוצר זה קיים");
            }
        }
    }
}
