using Models.EntityFramework;
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
        private ShopGameDbContext context = null;
        public AccountModel()
        {
            context = new ShopGameDbContext();
        }

        public bool Login(string userName, string password)
        {
            object[] sqlParams =
            {
                new SqlParameter("@UserName",userName),
                new SqlParameter("@PassWord",password)
            };
            var res = context.Database.SqlQuery<bool>("SP_Account_Login @UserName,@PassWord", sqlParams).SingleOrDefault();
            return res;
        }
    }
}
