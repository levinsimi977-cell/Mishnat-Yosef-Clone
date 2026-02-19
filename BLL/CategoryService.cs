using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MishnatYosef.Model;
namespace MishnatYosef.BLL
{
    public class CategoryService
    {    
            public static List<Category> GetList()
            {
                return Globaly.DB.Category.ToList();
            }
            public static void Add(Category c)
            {
            c.Code = Globaly.DB.Category.ToList().Count + 1;
            Globaly.DB.Category.Add(c);
            }
      
    }
}
