﻿namespace UI.TocHoPham.Areas.Admin.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string Username { get; set; }

        [MinLength(6, ErrorMessage = "Mật khẩu có tối thiểu 6 kí tự")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}