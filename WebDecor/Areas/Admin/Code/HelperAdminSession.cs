using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDecor.Areas.Admin.Code
{
    public class HelperAdminSession
    {
        public static void SetSession(AdminSession session)
        {
            HttpContext.Current.Session["loginSession"] = session;
        }

        public static AdminSession GetSession()
        {
            var session = HttpContext.Current.Session["loginSession"];
            if (session == null)
            {
                return null;
            }
            else
            {
                return session as AdminSession;
            }
        }
    }
}