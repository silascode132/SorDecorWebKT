using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebDecor.DATA.EF;

namespace WebDecor.DATA.DAO
{
    public class OrderDAO
    {
        private SorDbContext data = null;
        public OrderDAO()
        {
            data = new SorDbContext();
        }

        public string AddOrder(OrderBill model)
        {
            object[] sqlParams =
            {
                new SqlParameter("@UserID", model.UserID),
                new SqlParameter("@UserName", model.UserName),
                new SqlParameter("@UserAddress", model.UserAddress),
                new SqlParameter("@Phone", model.Phone),
                new SqlParameter("@Note", model.Note),
                new SqlParameter("@Paid", model.Paid),
                new SqlParameter("@DateOrder", model.DateOrder),
                new SqlParameter("@Email", model.Email),
            };
            string res = data.Database.SqlQuery<string>("sp_AddOrderBill @UserID, @UserName, @UserAddress, @Phone, @Note, @Paid, @DateOrder, @Email", sqlParams).SingleOrDefault();
            return res;
        }

        public bool UpdateSL(string id)
        {
            object[] sqlParams =
            {
                new SqlParameter("@ID", id),
            };
            bool res = data.Database.SqlQuery<bool>("sp_UpdateSLProduct @ID", sqlParams).SingleOrDefault();
            return res;
        }

        public IEnumerable<OrderBill> ListPagingForBill(int page, int pageSize, string id)
        {
            var bill = data.OrderBills.Where(x => x.UserID == id);

            return bill.OrderByDescending(x=>x.DateOrder).ToPagedList(page, pageSize);
        }

        public IEnumerable<OrderBill> ListPagingForPending(int page, int pageSize, string id)
        {
            var userbill = data.OrderBills.Where(x => x.UserID == id);
            var bill = userbill.Where(x => x.DeliverySTT == false);

            return bill.OrderByDescending(x=>x.DateOrder).ToPagedList(page, pageSize);
        }

        public IEnumerable<OrderBill> ListPagingForShipping(int page, int pageSize, string id)
        {
            var userbill = data.OrderBills.Where(x => x.UserID == id);
            var pendingbill = userbill.Where(x => x.DeliverySTT == true);
            var bill = pendingbill.Where(x => x.DeliveryDate == null);

            return bill.OrderByDescending(x => x.DateOrder).ToPagedList(page, pageSize);
        }
        public IEnumerable<OrderBill> ListPagingForDoneShip(int page, int pageSize, string id)
        {
            var userbill = data.OrderBills.Where(x => x.UserID == id);
            var pendingbill = userbill.Where(x => x.DeliverySTT == true);
            var bill = pendingbill.Where(x => x.DeliveryDate != null);

            return bill.OrderByDescending(x => x.DateOrder).ToPagedList(page, pageSize);
        }
    }
}