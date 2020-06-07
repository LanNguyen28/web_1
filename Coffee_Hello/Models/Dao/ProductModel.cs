using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductModel
    {
        public CoffeeDbContext context = null;

        public ProductModel()
        {
            context = new CoffeeDbContext();
        }

        public List<PRODUCT> ListAll()
        {
            var list = context.Database.SqlQuery<PRODUCT>("Sp_Product_ListAll").ToList();
            return list;
        }

        public List<PRODUCT> ListCoffee()
        {
            var list = context.Database.SqlQuery<PRODUCT>("Sp_Product_ListCoffee").ToList();
            return list;
        }

        public List<PRODUCT> ListDrink()
        {
            var list = context.Database.SqlQuery<PRODUCT>("Sp_Product_ListDrink").ToList();
            return list;
        }

        public List<PRODUCT> ListDessert()
        {
            var list = context.Database.SqlQuery<PRODUCT>("Sp_Product_ListDessert").ToList();
            return list;
        }

        public List<PRODUCT> ListMainDish()
        {
            var list = context.Database.SqlQuery<PRODUCT>("Sp_Product_ListMainDish").ToList();
            return list;
        }

        public int Create(string ProductName, string ProductDescription, string ImageLink, int Categoryid, int ProductPice, DateTime CreateDate , string Size)
        {
            object[] parameters =
            {
                new SqlParameter("@ProductName", ProductName),
                new SqlParameter("@ProductDescription", ProductDescription),
                new SqlParameter("@ImageLink", ImageLink),
                new SqlParameter("@Categoryid", Categoryid),
                new SqlParameter("@ProductPice", ProductPice),
                new SqlParameter("@createdate",CreateDate),
                new SqlParameter("@Size",Size),


            };
            int res = context.Database.ExecuteSqlCommand("Sp_Product_Insert @ProductName, @ProductDescription, @ImageLink,@ProductPice, @createdate,@size,@Categoryid", parameters);
            return res;
        }

        public int Edit(int id, string ProductName, string ProductDescription, string ImageLink, int Category, int ProductPice, string Size,DateTime createdate  )
        {
            object[] parameters =
            {
                new SqlParameter("@Productid", id),
                new SqlParameter("@ProductName", ProductName),
                new SqlParameter("@ProductDescription", ProductDescription),
                new SqlParameter("@ImageLink", ImageLink),
                new SqlParameter("@Categoryid", Category),
                new SqlParameter("@ProductPice", ProductPice),
                new SqlParameter("@size", Size),
                new SqlParameter("@createdate",createdate)
            };
            int res1 = context.Database.ExecuteSqlCommand("Sp_Product_Update @ProductName, @ProductDescription, @ImageLink, @Categoryid, @ProductPice, @Productid,@size, @createdate", parameters);
            return res1;
        }

        public int Delete(int id)
        {
            object[] parameters =
            {
                new SqlParameter("@id", id),
            };
            int res = context.Database.ExecuteSqlCommand("Sp_Product_Delete @id", parameters);
            return res;
        }
    }
}
