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
    /// Interaction logic for AdvertaismentPage.xaml
    /// </summary>
    public partial class AdvertaismentPage : Page
    {
        public AdvertaismentPage()
        {
            InitializeComponent();
            station.Text = BranchService.GetList().Count().ToString();
            clients.Text=ClientServise.GetList().Count().ToString();
            product.Text=ProductService.GetList().Count.ToString();
        }
    }
}
