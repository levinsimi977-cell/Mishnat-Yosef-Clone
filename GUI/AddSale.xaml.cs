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
    /// Interaction logic for AddSale.xaml
    /// </summary>
    public partial class AddSale : Page
    {
        Sale s;
        public AddSale()
        {
            InitializeComponent();
            s=new Sale();
            stp1.DataContext = s;
            //s.NameSale = nameSale.Text;
            //s.DateSale =date1 ;
            
        }

        private void addProduct_Click(object sender, RoutedEventArgs e)
        {
            
            myFrame.Navigate(new AddExaitedPM(s));
        }

        private void addlist_Click(object sender, RoutedEventArgs e)
        {
            
            myFrame.Navigate(new UpDateProducts(s));

        }

        private void lett_Click(object sender, RoutedEventArgs e)
        {
            if (Validation.GetHasError(nameSale)|| Validation.GetHasError(note))
                MessageBox.Show("יש שגיאה בנתונים");
            else if (nameSale.Text.Length < 2|| note.Text.Length < 2)
                MessageBox.Show("הנתונים לא הוכנסו כראוי");
           else 
           { 
            s.DateSale = date1.SelectedDate.Value;
            SaleService.Add(s);
            Globaly.UpdateDb();
            MessageBox.Show("התוסף בהצלחה");
          } 
        }
    }
}
