using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebDecor.DATA.EF;

namespace WebDecor.Models
{
    [Serializable]
    public class CartItemModel
    {
        SorDbContext context = null;


        public CartItemModel()
        {
            context = new SorDbContext();
        }

        public bool UpdateItem(string productID, int SL, string IDCart)
        {
            object[] sqlParams =
            {
                new SqlParameter("@ProductID", productID),
                new SqlParameter("@SL", SL),
                new SqlParameter("@IDCart", IDCart)
            };
            var res = context.Database.SqlQuery<bool>("sp_UpdateItem @ProductID, @SL, @IDCart", sqlParams).SingleOrDefault();
            return res;
        }


        public bool DeleteItem(string productID, string CartID)
        {
            object[] sqlParams =
            {
                new SqlParameter("@ProductID", productID),
                new SqlParameter("@CartID", CartID)
            };
            var res = context.Database.SqlQuery<bool>("sp_DeleteItemInCart @ProductID, @CartID", sqlParams).SingleOrDefault();
            return res;
        }
    }
}