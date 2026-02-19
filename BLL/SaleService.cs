using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MishnatYosef.Model;
namespace MishnatYosef.BLL
{
    public class SaleService
    {
        public static List<Sale> GetList()
        {
            return Globaly.DB.Sale.ToList();
        }
        public static void Add(Sale p)
        {
            p.Code = Globaly.DB.Sale.ToList().Count + 1;
            Globaly.DB.Sale.Add(p);
        }
    }
}
