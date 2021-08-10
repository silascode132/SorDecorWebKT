using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDecor.Areas.Admin.Code
{
    [Serializable]
    public class AdminSession
    {
        [Required]
        public string UserName { get; set; }
    }
}