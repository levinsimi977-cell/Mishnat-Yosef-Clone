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
    /// Interaction logic for AddCity.xaml
    /// </summary>
    public partial class AddCity : Page
    {
        City c,c2;
        public AddCity()
        {
            InitializeComponent();
            c = new City();
           stp.DataContext=c;
            lstv.ItemsSource = CityService.GetList();
        }
        private void lett_Click(object sender, RoutedEventArgs e)
        {
            if (Validation.GetHasError(name))
                MessageBox.Show("יש שגיאה בנתונים");
            else if (name.Text.Length < 2)
                MessageBox.Show("הנתונים לא הוכנסו כראוי");
           else 
           {

            c2 = CityService.GetList().FirstOrDefault(x => x.Name == c.Name);

            if (c2== null)
            {
                CityService.Add(c);
                Globaly.UpdateDb();
                MessageBox.Show("התוסף בהצלחה");
                    lstv.ItemsSource = null;
                    lstv.ItemsSource =CityService.GetList();
                }
            else
                MessageBox.Show("עיר זו קימת");
           }
        }
    }
}
