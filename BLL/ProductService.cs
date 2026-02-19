using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MishnatYosef.Model;
namespace MishnatYosef.BLL
{
    public class ProductService
    {
            public static List<Product> GetList()
            {
                return Globaly.DB.Product.ToList();
            }
            public static void Add(Product c)
            {
                c.Code = Globaly.DB.Product.ToList().Count + 1;
                Globaly.DB.Product.Add(c);
            }
      
    }
}
