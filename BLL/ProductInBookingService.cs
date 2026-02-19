using MishnatYosef.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MishnatYosef.BLL
{
    public class ProductInBookingService
    {
        public static List<ProductInBooking> GetList()
        {
            return Globaly.DB.ProductInBooking.ToList();
        }
        public static void Add(ProductInBooking c)
        {
            c.Code = Globaly.DB.ProductInBooking.ToList().Count + 1;
            Globaly.DB.ProductInBooking.Add(c);
        }
    }
}
