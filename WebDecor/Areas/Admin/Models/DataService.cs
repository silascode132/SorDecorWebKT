using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDecor.Areas.Admin.Data.DAO;
using WebDecor.DATA.EF;

namespace WebDecor.Areas.Admin.Models
{
    public static class DataService
    {
        public static List<DataPoints> GetData()
        {

            List<DataPoints> _datapoint = new List<DataPoints>();
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            DateTime firstofmonth = DateTime.Parse(1 + "/" + month + "/" + year + " 00:00:00 AM");
            for (int i = 1; i < day + 1; i++)
            {
                DateTime beginday = DateTime.Parse(month + "/" + i + "/" + year + " 00:00 AM");
                DateTime endday = DateTime.Parse(month + "/" + i + "/" + year + " 11:59 PM");


                decimal revenue = new DataChartDAO().getRevenue(beginday, endday);
                _datapoint.Add(new DataPoints(i, revenue));
            }
            return _datapoint;

        }
    }
}