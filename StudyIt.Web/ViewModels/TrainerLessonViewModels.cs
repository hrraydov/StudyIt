using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyIt.Web.ViewModels
{
    public class TrainerLessonIndexViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Group { get; set; }
        public string Subcategory { get; set; }
        public string Category { get; set; }
    }

    public class TrainerLessonDetailsViewModel
    {
        [Display(Name = "Заглавие")]
        public string Title { get; set; }
        [Display(Name = "Съдържание")]
        public string Content { get; set; }
        [Display(Name = "Автор")]
        public string Author { get; set; }
        [Display(Name = "Дата на създаване")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "Подкатегория")]
        public string SubcategoryName { get; set; }
        [Display(Name = "Категория")]
        public string CategoryName { get; set; }
        [Display(Name = "Група")]
        public string GroupName { get; set; }
    }

    public class TrainerLessonCreateViewModel
    {
        [Required(ErrorMessage = "Въведете заглавие")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Заглавието трябва да е между 2 и 100 символа")]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Въведете съдържание")]
        [StringLength(4000, MinimumLength = 10, ErrorMessage = "Съдържанието трябва да е ежду 10 и 4000 символа")]
        [Display(Name = "Съдържание")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Въведете подкатегория")]
        [Display(Name = "Подкатегория")]
        public int SubcategoryId { get; set; }
        public SelectList Groups { get; set; }
    }

    public class TrainerLessonEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Въведете заглавие")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Заглавието трябва да е между 2 и 100 символа")]
        [Display(Name = "Заглавие")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Въведете съдържание")]
        [StringLength(4000, MinimumLength = 10, ErrorMessage = "Съдържанието трябва да е ежду 10 и 4000 символа")]
        [Display(Name = "Съдържание")]
        public string Content { get; set; }
    }

    public class TrainerLessonDeleteViewModel
    {
        [Display(Name = "Заглавие")]
        public string Title { get; set; }
        [Display(Name = "Автор")]
        public string Author { get; set; }
        [Display(Name = "Дата на създаване")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "Подкатегория")]
        public string SubcategoryName { get; set; }
        [Display(Name = "Категория")]
        public string CategoryName { get; set; }
        [Display(Name = "Група")]
        public string GroupName { get; set; }
    }
}
