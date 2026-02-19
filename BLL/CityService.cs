using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MishnatYosef.Model;
namespace MishnatYosef.BLL
{
    public class CityService
    {
        public static List<City> GetList()
        {
            return Globaly.DB.City.ToList();
        }
        public static void Add(City c)
        {
            c.Code = Globaly.DB.City.ToList().Count + 1;
            Globaly.DB.City.Add(c);
        }
    }
}
