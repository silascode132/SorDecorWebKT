using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebDecor.DATA.EF;

namespace WebDecor.Areas.Admin.Data.DAO
{
    public class DataChartDAO
    {
        private SorDbContext data = null;
        public decimal getRevenue(DateTime begin, DateTime end)
        {
            data = new SorDbContext();

            object[] sqlParams =
            {
                new SqlParameter("@Begin", begin),
                new SqlParameter("@End", end),
                //new SqlParameter("@date", begin),
            };
            decimal res = data.Database.SqlQuery<decimal>("sp_CalculateForDay @Begin, @End", sqlParams).SingleOrDefault();

            //DateTime test = data.Database.SqlQuery<DateTime>("sp_Test @date", sqlParams).SingleOrDefault();

            //DateTime sss = test;
            //decimal res = (decimal)2.4;
            return res;
        }
    }
}