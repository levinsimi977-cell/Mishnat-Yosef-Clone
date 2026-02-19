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
using MishnatYosef.GUI;
using MishnatYosef.BLL;
using MishnatYosef.Model;

namespace MishnatYosef
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Client c;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void maneger_Click(object sender, RoutedEventArgs e)
        {
            if (Validation.GetHasError(id) || Validation.GetHasError(phone) ||Validation.GetHasError(name))
                MessageBox.Show("יש שגיאה בנתונים");
           
            else
            {
                if (id.Text == "329177059")
                {
                    Window1 mp = new Window1();
                    this.Close();
                    mp.Show();
                }
                else
                    MessageBox.Show("אין לך אשרת גישה");
            }

        }

        private void client_Click(object sender, RoutedEventArgs e)
        {
           if (Validation.GetHasError(id) || Validation.GetHasError(phone) || Validation.GetHasError(name))
                MessageBox.Show("יש שגיאה בנתונים");
         
            else
            {
                c = ClientServise.GetList().FirstOrDefault(x => x.ClientId == int.Parse(id.Text));
                if (c != null)
                {

                    Globaly.UserId = c.ClientId;
                    Window1 mp = new Window1();
                    this.Close();
                    mp.ShowDialog();
                }
                else
                {
                    MessageBoxResult ans = MessageBox.Show("?האם ברצונך להרשם", ",עדין אינך רשום",MessageBoxButton.OKCancel);
                    if (ans == MessageBoxResult.OK)
                    {
                        Window1 mp = new Window1();
                        this.Close();
                       mp.ShowDialog();

                    }
                    
                }
            }
        }

    }
}
