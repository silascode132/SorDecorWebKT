using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebDecor.DATA.EF;

namespace WebDecor.Areas.Admin.Data.DAO
{
    public class PendingOrderDAO
    {
        SorDbContext data = null;
        public PendingOrderDAO()
        {
            data = new SorDbContext();
        }

        public bool ConfirmOrder(string ID)
        {
            object[] sqlParams =
            {
                new SqlParameter("@ID", ID),
            };
            bool res = data.Database.SqlQuery<bool>("sp_Confirm @ID", sqlParams).SingleOrDefault();
            return res;
        }

        public bool UnConfirmOrder(string ID)
        {
            object[] sqlParams =
            {
                new SqlParameter("@ID", ID),
            };
            bool res = data.Database.SqlQuery<bool>("sp_UnConfirm @ID", sqlParams).SingleOrDefault();
            return res;
        }

        public bool CompleteDelivery(string ID)
        {
            object[] sqlParams =
            {
                new SqlParameter("@ID", ID),
            };
            bool res = data.Database.SqlQuery<bool>("sp_CompleteDeli @ID", sqlParams).SingleOrDefault();

            return res;
        }
    }
}