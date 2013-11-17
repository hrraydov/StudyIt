using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudyIt.Web.ViewModels
{
    public class TrainerQuestionEditViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Въпрос")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Въпросът трябва да е между 2 и 100 символа")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Отговор 1")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Отговорът трябва да е между 2 и 100 символа")]
        public string Answer1 { get; set; }
        [Required]
        [Display(Name = "Отговор 2")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Отговорът трябва да е между 2 и 100 символа")]
        public string Answer2 { get; set; }
        [Required]
        [Display(Name = "Отговор 3")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Отговорът трябва да е между 2 и 100 символа")]
        public string Answer3 { get; set; }
        [Required]
        [Display(Name = "Отговор 4")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Отговорът трябва да е между 2 и 100 символа")]
        public string Answer4 { get; set; }
        [Required]
        [Display(Name = "Брой точки")]
        public int Value { get; set; }
        [Required]
        [Display(Name = "Верен отговор")]
        public int TrueAnswer { get; set; }
        [Required]
        public int TestId { get; set; }
    }

    public class TrainerQuestionDeleteViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Въпрос")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Въпросът трябва да е между 2 и 100 символа")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Отговор 1")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Отговорът трябва да е между 2 и 100 символа")]
        public string Answer1 { get; set; }
        [Required]
        [Display(Name = "Отговор 2")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Отговорът трябва да е между 2 и 100 символа")]
        public string Answer2 { get; set; }
        [Required]
        [Display(Name = "Отговор 3")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Отговорът трябва да е между 2 и 100 символа")]
        public string Answer3 { get; set; }
        [Required]
        [Display(Name = "Отговор 4")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Отговорът трябва да е между 2 и 100 символа")]
        public string Answer4 { get; set; }
        [Required]
        [Display(Name = "Брой точки")]
        public int Value { get; set; }
        [Required]
        [Display(Name = "Верен отговор")]
        public int TrueAnswer { get; set; }
        [Required]
        public int TestId { get; set; }
    }

    public class TrainerQuestionCreateViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Въпрос")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Въпросът трябва да е между 2 и 100 символа")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Отговор 1")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Отговорът трябва да е между 2 и 100 символа")]
        public string Answer1 { get; set; }
        [Required]
        [Display(Name = "Отговор 2")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Отговорът трябва да е между 2 и 100 символа")]
        public string Answer2 { get; set; }
        [Required]
        [Display(Name = "Отговор 3")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Отговорът трябва да е между 2 и 100 символа")]
        public string Answer3 { get; set; }
        [Required]
        [Display(Name = "Отговор 4")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Отговорът трябва да е между 2 и 100 символа")]
        public string Answer4 { get; set; }
        [Required]
        [Display(Name = "Верен отговор")]
        public int TrueAnswer { get; set; }
        [Required]
        [Display(Name = "Брой точки")]
        public int Value { get; set; }
        [Required]
        public int TestId { get; set; }
    }
}