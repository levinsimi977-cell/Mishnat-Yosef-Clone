using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MishnatYosef.Model;
namespace MishnatYosef.BLL
{
    public class ProductTrandService
    {
        public static List<ProductTrand> GetList()
        {
            return Globaly.DB.ProductTrand.ToList();
        }
        public static void Add(ProductTrand p)
        {
            p.Code = Globaly.DB.ProductTrand.ToList().Count + 1;
            Globaly.DB.ProductTrand.Add(p);
        }
    }
}
