using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDecor.Models
{
    public class LoginModel
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string passWord { get; set; }
        public object UserController { get; set; }
    }
}