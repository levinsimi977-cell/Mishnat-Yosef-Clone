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
    /// Interaction logic for CreditCardCPage.xaml
    /// </summary>
    public partial class CreditCardCPage : Page
    {
        Client c;
        public CreditCardCPage(Client c)
        {
            InitializeComponent();    
            this.c = c;
            stp1.DataContext = c;
            if(Globaly.UserId==0)
            {
                upDate.Content = "להוספה לרשימת הלקוחות";
            }
        }
        private void upDate_Click(object sender, RoutedEventArgs e)
        {
            if (Validation.GetHasError(tnumber)|| Validation.GetHasError(cnumber))
                MessageBox.Show("יש שגיאה בנתונים");
            else if (tnumber.Text.Length !=3||cnumber.Text.Length<3)
                MessageBox.Show("הנתונים לא הוכנסו כראוי");
            else {
            stp1.DataContext = c;

            if (Globaly.UserId == 0)
            {               
                ClientServise.Add(c);
                Globaly.UpdateDb();
                Globaly.UserId = c.ClientId;
                MessageBox.Show("נרשמת בהצלחה");
              
            }
            Globaly.UpdateDb();
            }
        }
    }
}
