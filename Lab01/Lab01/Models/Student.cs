using System;
using System.ComponentModel.DataAnnotations;

namespace Lab01.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Họ tên bắt buộc phải nhập")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email bắt buộc phải được nhập")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email không hợp lệ")]
        public string? Email { get; set; }

        [StringLength(100, MinimumLength = 8,
            ErrorMessage = "Mật khẩu phải từ 8 ký tự trở lên")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Ngành học bắt buộc chọn")]
        public Branch? Branch { get; set; }

        [Required(ErrorMessage = "Giới tính bắt buộc chọn")]
        public Gender? Gender { get; set; }

        public bool IsRegular { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Ngày sinh bắt buộc phải nhập")]
        [DataType(DataType.Date)]
        [BirthdateValidation]
        public DateTime DateOfBirth { get; set; }
    }

    public class BirthdateValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            DateTime dob = (DateTime)value;

            if (dob < new DateTime(1963, 1, 1) || dob > new DateTime(2005, 12, 31))
            {
                ErrorMessage = "Ngày sinh phải từ 01/01/1963 đến 31/12/2005";
                return false;
            }

            return true;
        }
    }
}
