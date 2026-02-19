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
    /// Interaction logic for AddBranch.xaml
    /// </summary>
    public partial class AddBranch : Page
    {
        Branch b,b2;
        public AddBranch()
        {
            InitializeComponent();
            b=new Branch();
            cmbC.DataContext = CityService.GetList();
            cmbC.ItemsSource = CityService.GetList();
            stp.DataContext = b;
            lstv.ItemsSource = BranchService.GetList();
        }

        private void lett_Click(object sender, RoutedEventArgs e)
        {
            if (Validation.GetHasError(adress) || Validation.GetHasError(nhouse) || Validation.GetHasError(mphone) || Validation.GetHasError(from) || Validation.GetHasError(still))
                    MessageBox.Show("יש שגיאה בנתונים");
            else if ((adress.Text).Length < 2 || nhouse.Text.Length <1 || mphone.Text.Length < 2|| from.Text.Length < 1||still.Text.Length < 1)
                    MessageBox.Show("הנתונים לא הוכנסו כראוי");
            else {
            b.City1 = cmbC.SelectedItem as City;
            b.Address = adress.Text;
            b.StillHour =int.Parse(still.Text);
            b.FromHour=int.Parse(from.Text);
            b.ManegerPhone=mphone.Text;
            b.NumHouse = int.Parse(nhouse.Text);
            b2 = BranchService.GetList().FirstOrDefault(x => x.City1== b.City1);

            if (b2 != null)
            {
                BranchService.Add(b);
                Globaly.UpdateDb();
                MessageBox.Show("התוסף בהצלחה");
                lstv.ItemsSource =null;
                lstv.ItemsSource = BranchService.GetList();
                }
            else
              MessageBox.Show("סניף זה קיים");
           } 
        }
    }
}
