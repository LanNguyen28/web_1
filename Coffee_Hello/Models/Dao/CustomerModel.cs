using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CustomerModel
    {
        public CoffeeDbContext context = null;

        public CustomerModel()
        {
            context = new CoffeeDbContext();
        }

        public List<CUSTOMER> ListAll()
        {
            var list = context.Database.SqlQuery<CUSTOMER>("Sp_Customer_ListAll").ToList();
            return list;
        }
    }
}
