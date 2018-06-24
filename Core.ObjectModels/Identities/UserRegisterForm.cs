namespace Core.ObjectModels.Identities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserRegisterForm
    {
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [MinLength(6, ErrorMessage = "Mật khẩu có tối thiểu 6 kí tự")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Mật khẩu của bạn không khớp")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Tên người sử dụng không được để trống")]
        public string FullName { get; set; }

        public string Address { get; set; }

        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Phone { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Ngày sinh không hợp lệ")]
        public DateTime DateOfBirth { get; set; }
    }
}
