using System.ComponentModel.DataAnnotations;

namespace WebDecor.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Mời nhập tên đăng nhập")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Mời nhập Email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Mời nhập tên")]
        public string name { get; set; }

        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string pass { get; set; }

        [Required(ErrorMessage = "Mật khẩu không đúng")]
        public string rePass { get; set; }
    }
}