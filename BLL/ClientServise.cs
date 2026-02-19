using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MishnatYosef.Model;
namespace MishnatYosef.BLL
{
    public class ClientServise
    {
        public static List<Client> GetList()
        {
            return Globaly.DB.Client.ToList();
        }
        public static void Add(Client c)
        {
            Globaly.DB.Client.Add(c);
        }
       
    }
}
