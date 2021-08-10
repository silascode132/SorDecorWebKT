using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebDecor.DATA.EF;

namespace WebDecor.DATA.DAO
{
    public class CartItemDAO
    {
        private SorDbContext data = null;

        public CartItemDAO()
        {
            data = new SorDbContext();
        }

        public bool UpdateItem(string idProduct, int SL, string idcart)
        {
            object[] sqlParams =
            /*var sqlParams = new SqlParameter[]*/
            {
                new SqlParameter("@IDCart", idcart),
                new SqlParameter("@IDProduct", idProduct),
                new SqlParameter("@SL", SL),
            };
            bool res = data.Database.SqlQuery<bool>("sp_UpdateSLItemInCart @IDCart, @IDProduct, @SL", sqlParams).SingleOrDefault();
            return res;

        }
    }
}