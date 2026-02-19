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
using MishnatYosef.BLL;
using MishnatYosef.Model;

namespace MishnatYosef.GUI
{
    /// <summary>
    /// Interaction logic for ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Window
    {
        Client c;
        public ClientPage()
        {
            InitializeComponent();
                cFrame.Navigate(new PrivateDetailsCPage());
               
                c=ClientServise.GetList().FirstOrDefault(x=>x.ClientId==Globaly.UserId);
               
           
        }
        public ClientPage(Client c1)
        {
            InitializeComponent();
            c = c1;

            title.Text = "שלום ל" + c.FName + " " + c.LName;

        }

        private void privateDetails_Click(object sender, RoutedEventArgs e)
        {
            Client c = ClientServise.GetList().FirstOrDefault(x => x.ClientId == Globaly.UserId);
            if (c != null)
            {
                title.Text = "שלום ל" + c.FName + " " + c.LName;
                cFrame.Navigate(new PrivateDetailsCPage(c));
            }
            else
               cFrame.Navigate(new PrivateDetailsCPage());
        }

   

        private void CreditCard_Click(object sender, RoutedEventArgs e)
        {
            Client c;
            c=ClientServise.GetList().FirstOrDefault(x=>x.ClientId == Globaly.UserId);
            if( c != null)
            {
                title.Text = "שלום ל" + c.FName + " " + c.LName;
                cFrame.Navigate(new CreditCardCPage(c));
             }
            else
            {
                c=new Client();
            cFrame.Navigate(new CreditCardCPage(c));
            }

        }

        private void Booking_Click(object sender, RoutedEventArgs e)
        {
            cFrame.Navigate(new BookingCPage());


        }
        private void enter_Click(object sender, RoutedEventArgs e)
        {
          

            if (Globaly.UserId != 0)
            { 
                c = ClientServise.GetList().FirstOrDefault(x => x.ClientId == Globaly.UserId);
                cFrame.Navigate(new OrderProductC());
                title.Text = "שלום ל" + c.FName + " " + c.LName;

            }
            else
                MessageBox.Show(".אינך קיים במערכת,עליך להרשם");
            Acquittal1.Visibility = Visibility.Hidden;

        }

        private void Acquittal_Click(object sender, RoutedEventArgs e)
        {

            Client c = ClientServise.GetList().FirstOrDefault(x => x.ClientId == Globaly.UserId);
            Acquittal1.Visibility = Visibility.Visible;
            if (c != null)
            {
                title.Text = "שלום ל" + c.FName + " " + c.LName;
                Acquittal1.Text = "סכום זיכוי  " + c.SumAcquittal.ToString();
            }
            else
                MessageBox.Show("אינך קיים במערכת");



        }
    }
}
