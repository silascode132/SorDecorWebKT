using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebDecor.DATA.EF;

namespace WebDecor.DBContext
{
    public class AccountModel
    {
        private SorDbContext data = null;
        public AccountModel()
        {
            data = new SorDbContext();
        }
        public bool Login(string username, string password)
        {
            object[] sqlParams =
            /*var sqlParams = new SqlParameter[]*/
            {
                new SqlParameter("@UserName", username),
                new SqlParameter("@Pass", password),
            };
            var res = data.Database.SqlQuery<bool>("sp_Login @UserName, @Pass", sqlParams).SingleOrDefault();
            return res;
        }


        public bool AdminLogin(string username, string password)
        {
            object[] sqlParams =
            {
                new SqlParameter("@Acc", username),
                new SqlParameter("@Pass", password),
            };
            var res = data.Database.SqlQuery<bool>("sp_AdminLogin @Acc, @Pass", sqlParams).SingleOrDefault();
            return res;
        }
    }
}