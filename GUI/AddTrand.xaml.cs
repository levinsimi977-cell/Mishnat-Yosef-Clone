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
    /// Interaction logic for AddTrand.xaml
    /// </summary>
    public partial class AddTrand : Page
    {
        ProductTrand pt, pt2;
        public AddTrand()
        {
            InitializeComponent();
            pt = new ProductTrand();
            this.DataContext = pt;
            lstv.ItemsSource = ProductTrandService.GetList();
        }
        private void lett_Click(object sender, RoutedEventArgs e)
        {
            if (Validation.GetHasError(name))
                MessageBox.Show("יש שגיאה בנתונים");
            else if (name.Text.Length < 2)
                MessageBox.Show("הנתונים לא הוכנסו כראוי");
            else
            {
                pt2 = ProductTrandService.GetList().FirstOrDefault(x => x.Name == pt.Name);

                if (pt2 == null)
                {
                    ProductTrandService.Add(pt);
                    Globaly.UpdateDb();
                    MessageBox.Show("התוסף בהצלחה");
                    lstv.ItemsSource = null;
                    lstv.ItemsSource = ProductTrandService.GetList();
                }
                else
                    MessageBox.Show("המותג קיים");
            }
        }
    }
}
