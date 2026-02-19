using MishnatYosef.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MishnatYosef.BLL
{
    public class BranchService
    {     
            public static List<Branch> GetList()
            {
                return Globaly.DB.Branch.ToList();
            }
            public static void Add(Branch b)
            {
            b.Code = Globaly.DB.Branch.ToList().Count + 1;
            Globaly.DB.Branch.Add(b);
            }
       

    }
}
