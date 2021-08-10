using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDecor.Code
{
    [Serializable]
    public class UserSession
    {
        public string userName { get; set; }
        public string userID { get; set; }
    }
}