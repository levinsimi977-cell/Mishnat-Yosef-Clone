using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MishnatYosef.Model;
namespace MishnatYosef.BLL
{
    public class Globaly
    {
        public static MishnatYosefEntities DB { get; set; }
        public static int UserId { get; set; }
        public static void UpdateDb()
        {
            DB.SaveChanges();
        }
        static Globaly()
        {
            DB= new MishnatYosefEntities();
        }
    }
}
