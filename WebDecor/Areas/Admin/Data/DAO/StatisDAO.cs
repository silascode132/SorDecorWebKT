using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDecor.DATA.EF;

namespace WebDecor.Areas.Admin.Data.DAO
{
    public class StatisDAO
    {
        SorDbContext data = null;
        public StatisDAO()
        {
            data = new SorDbContext();
        }

        public decimal RevenueMonth()
        {
            decimal res = data.Database.SqlQuery<decimal>("sp_EarningPerMonth").SingleOrDefault();
            return res;
        }

        public decimal RevenueYear()
        {
            decimal res = data.Database.SqlQuery<decimal>("sp_EarningPerYear").SingleOrDefault();
            return res;
        }
    }
}