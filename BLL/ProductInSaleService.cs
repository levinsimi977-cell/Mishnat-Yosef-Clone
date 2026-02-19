using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MishnatYosef.Model;

namespace MishnatYosef.BLL
{
    public class ProductInSaleService
    {
       
            public static List<ProductInSale> GetList()
            {
                return Globaly.DB.ProductInSale.ToList();
            }
            public static void Add(ProductInSale c)
            {
                c.Code = Globaly.DB.ProductInSale.ToList().Count + 1;
                Globaly.DB.ProductInSale.Add(c);
            }
      
    }
}
