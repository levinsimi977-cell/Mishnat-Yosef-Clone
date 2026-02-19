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
using System.Windows.Shapes;
using MishnatYosef.Model;
namespace MishnatYosef.GUI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {  
        Client c;
        public Window1()
        {
            InitializeComponent();
        }
            private void maneger_Click(object sender, RoutedEventArgs e)
            {
            string s = id.Text;

            int x;
            if (!int.TryParse(s, out x))
                MessageBox.Show("יש שגיאה בנתונים");

            else if (s.Length < 5 || s.Length > 9)
                MessageBox.Show("יש שגיאה בנתונים");

            for (int i = s.Length; i < 9; i++)
                s = "0" + s;
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int k = ((i % 2) + 1) * (Convert.ToInt32(s[i]) - '0');
                if (k > 9)
                    k -= 9;
                sum += k;

            }
            if (sum % 10 != 0)
                MessageBox.Show("יש שגיאה בנתונים");
            else
            {
                if (id.Text == "329177059")
                {
                    ManegerPage mp = new ManegerPage();
                    this.Close();
                    mp.Show();
                }
                else
                    MessageBox.Show("אין לך אשרת גישה");
            }

            }

            private void client_Click(object sender, RoutedEventArgs e)
            {
            string s = id.Text;

            int x;
            if (!int.TryParse(s, out x))
                MessageBox.Show("יש שגיאה בנתונים");

            else if (s.Length < 5 || s.Length > 9)
                MessageBox.Show("יש שגיאה בנתונים");

            for (int i = s.Length; i < 9; i++)
                s = "0" + s;
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int k = ((i % 2) + 1) * (Convert.ToInt32(s[i]) - '0');
                if (k > 9)
                    k -= 9;
                sum += k;

            }

            if (sum % 10 != 0)
                MessageBox.Show("יש שגיאה בנתונים");
            else
                {
                    c = ClientServise.GetList().FirstOrDefault(y=> y.ClientId == int.Parse(id.Text));
                    if (c != null)
                    {

                        Globaly.UserId = c.ClientId;
                        ClientPage cp = new ClientPage(c);
                        this.Close();
                        cp.ShowDialog();
                    }
                    else
                    {
                        MessageBoxResult ans = MessageBox.Show("?האם ברצונך להרשם", ",עדין אינך רשום", MessageBoxButton.OKCancel);
                        if (ans == MessageBoxResult.OK)
                        {
                            ClientPage cp = new ClientPage();
                            this.Close();
                            cp.ShowDialog();

                        }

                    }
                }
            }

        //private void id_PreviewTextInput(object sender, TextCompositionEventArgs e)
        //{
        //    if(e.Text >="0")
        //       e.Handled = true;
        //}

        //private void name_KeyDown(object sender, KeyEventArgs e)
        //{
        //    //לאפשר לו רק אותיות
        //    if ((char)e.Key >='a'&&(char)e.Key>='z')
        //        e.Handled = true;

        //}
        //private void id_KeyDown(object sender, KeyEventArgs e)
        //{
        //    //לאפשר לו רק מספרים
        //    if ((char)e.Key <= '9' && (char)e.Key >= '0')
        //        e.Handled = true;

        //}

        //private void phone_KeyDown(object sender, KeyEventArgs e)
        //{
        //    //לאפשר לו רק מספרים
        //    if ((int)e.Key <= 9 && (int)e.Key >= 0)
        //        e.Handled = true;

        //}
    }
}
