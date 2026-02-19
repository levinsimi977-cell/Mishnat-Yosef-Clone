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
    /// Interaction logic for AddCategory.xaml
    /// </summary>
    public partial class AddCategory : Page
    {
        Category c,c2;
        public AddCategory()
        {
            InitializeComponent();
            c= new Category();
            this.DataContext = c;
            lstv.ItemsSource=CategoryService.GetList();
        }
        private void lett_Click(object sender, RoutedEventArgs e)
        {
            if (Validation.GetHasError(name))
                MessageBox.Show("יש שגיאה בנתונים");
           else if(name.Text.Length<2)
                MessageBox.Show("הנתונים לא הוכנסו כראוי");
            else {
            c2 = CategoryService.GetList().FirstOrDefault(x => x.Name== c.Name);

            if (c2== null)
            {
                CategoryService.Add(c);
                Globaly.UpdateDb();
                MessageBox.Show("התוסף בהצלחה");
                    lstv.ItemsSource = null;
                    lstv.ItemsSource =CategoryService.GetList();
                }
            else
                MessageBox.Show("קטגוריה זו קיימת");
        }
        }
    }
}
