using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDecor.Areas.Admin.Common
{
    [Serializable]
    public class AdminUserLogin
    {
        [Required]
        public string userID { get; set; }
        [Required]
        public string userName { get; set; }
        
    }
}