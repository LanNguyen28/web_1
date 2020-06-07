using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AccountModel
    {
        public CoffeeDbContext context = null;

        public AccountModel()
        {
            context = new CoffeeDbContext();
        }

        public bool Login(string userName, string Password)
        {
            object[] sqlParams =
            {
                new SqlParameter("@UserName",userName),
                new SqlParameter("@Password",Password),
            };
            var res =
                context.Database.SqlQuery<bool>("Sp_Account_Login @UserName,@Password", sqlParams).SingleOrDefault();
            return res;
        }
    }
}
