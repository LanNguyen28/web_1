using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CategoryModel
    {
        public CoffeeDbContext context = null;

        public CategoryModel()
        {
            context = new CoffeeDbContext();
        }

        public List<CATEGORY> ListAll()
        {
            var list = context.Database.SqlQuery<CATEGORY>("Sp_Category_ListAll").ToList();
            return list;
        }
    }
}
