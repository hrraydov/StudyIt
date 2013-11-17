using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace StudyIt.Models
{

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "Потребителско име")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Стара парола")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Паролата трябва да бъде между 6 и 100 символа", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Нова парола")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повтори новата парола")]
        [Compare("NewPassword", ErrorMessage = "Паролите не съвпадат")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "Потребителско име")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [Display(Name = "Запомни ме?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "Потребителско име")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Паролата трябва да е между 6 и 100 символа", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повтори парола")]
        [Compare("Password", ErrorMessage = "Паролите не съвпадат")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
