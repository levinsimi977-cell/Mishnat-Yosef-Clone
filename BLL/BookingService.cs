using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MishnatYosef.Model;
namespace MishnatYosef.BLL
{
    public class BookingService
    {
        public static List<Booking> GetList()
        {
            return Globaly.DB.Booking.ToList();
        }
        public static void Add(Booking b)
        {
            b.Code = Globaly.DB.Booking.ToList().Count + 1;
            Globaly.DB.Booking.Add(b);
        }
    }
}
