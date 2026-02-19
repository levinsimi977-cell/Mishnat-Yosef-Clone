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
    /// Interaction logic for PrivateDetailsCPage.xaml
    /// </summary>
    public partial class PrivateDetailsCPage : Page
    {
        Client c1;
        public PrivateDetailsCPage()
        {
            InitializeComponent();

            cmbC.ItemsSource = CityService.GetList();
            c1 = new Client();
            stp1.DataContext = c1;
            stp2.DataContext = c1;
            upDate.Content = "המשך";
        }
        public PrivateDetailsCPage(Client c)
        {
            InitializeComponent();
            cmbC.ItemsSource = CityService.GetList();
            City city=c.City1;
            lstv.DataContext = BranchService.GetList().Where(x=>x.City1==city);
            lstv.ItemsSource = BranchService.GetList().Where(x => x.City1 == city);
           
            c1 = c;
            stp1.DataContext = c1;
            stp2.DataContext = c1;
            ca.Text = c.City1.Name.ToString();
            ba.Text=c.Branch.City1.Name+" "+c.Branch.Address+" "+c.Branch.NumHouse.ToString();
        }

        private void upDate_Click(object sender, RoutedEventArgs e)
        {
            if (Validation.GetHasError(fname)|| Validation.GetHasError(lname) || Validation.GetHasError(id) || Validation.GetHasError(addres) || Validation.GetHasError(numhouse) || Validation.GetHasError(phone))
                MessageBox.Show("יש שגיאה בנתונים");
            else if (fname.Text.Length < 2|| lname.Text.Length < 2  )
                MessageBox.Show("הנתונים לא הוכנסו כראוי");
           else
           {
            if (upDate.Content == "המשך")
            {  
                c1.City1 = cmbC.SelectedItem as City;
                    c1.Adrees = addres.Text;

                c1.SumAcquittal = 0;
                if (lstv.SelectedItems.Count == 1)
                {
                    Branch b = lstv.SelectedItem as Branch;
                    c1.Branch = b;
                        c1.City = c1.City1.Code;
                        c1.CodeBranch = c1.Branch.Code;
                    NavigationService.Navigate(new CreditCardCPage(c1));
                        Globaly.UpdateDb();
                    }
                    else

                    MessageBox.Show("לא מולאו כלל הפרטים");
                
            
            }
            else
            {
                if (cmbC.SelectedItem != null)
                    c1.City1 = cmbC.SelectedItem as City;
                else
                {
                    c1 = ClientServise.GetList().FirstOrDefault(x => x.ClientId == Globaly.UserId);
                    c1.City1 = c1.City1;
                }
                c1.SumAcquittal = c1.SumAcquittal;     
                if (lstv.SelectedItems.Count == 1)
                {
                    Branch b = lstv.SelectedItem as Branch;
                    c1.Branch = b;
                }
                else
                    c1.Branch = c1.Branch;
                stp1.DataContext = c1;
                stp2.DataContext = c1;
                    ca.Text = c1.City1.Name.ToString();
                    ba.Text = c1.Branch.City1.Name + " " + c1.Branch.Address + " " + c1.Branch.NumHouse.ToString();
                    Globaly.UpdateDb();
                    MessageBox.Show("הועדכן");
         }  }
        }
        private void cmbC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            City city;
            city = cmbC.SelectedItem as City;
            lstv.DataContext = BranchService.GetList().Where(x=>x.City1==city);
            lstv.ItemsSource = BranchService.GetList().Where(x=>x.City1==city);
        }
    }
}
