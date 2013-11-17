using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyIt.Web.ViewModels
{
    public class TrainerTestCreateViewModel
    {
        [Required(ErrorMessage = "Въведете име")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Името трябва да е между 2 и 100 символа")]
        [Display(Name = "Име")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Въведете подкатегория")]
        [Display(Name = "Подкатегория")]
        public int SubcategoryId { get; set; }
        [Display(Name = "Покажи верните отговори след решаване")]
        public bool ShowTrueAnswers { get; set; }
        public SelectList Groups { get; set; }
    }

    public class TrainerTestIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public string Subcategory { get; set; }
        public string Category { get; set; }
        public int QuestionNumber { get; set; }
    }

    public class TrainerTestDetailsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Име")]
        public string Name { get; set; }
        [Display(Name = "Автор")]
        public string Author { get; set; }
        [Display(Name = "Подкатегория")]
        public string SubcategoryName { get; set; }
        [Display(Name = "Категория")]
        public string CategoryName { get; set; }
        [Display(Name = "Група")]
        public string GroupName { get; set; }
        [Display(Name = "Брой въпроси")]
        public int QuestionNumber { get; set; }
        public List<Question> Questions { get; set; }
    }

    public class TrainerTestEditViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Въведете име")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Името трябва да е между 2 и 100 символа")]
        [Display(Name = "Име")]
        public string Name { get; set; }
    }

    public class TrainerTestDeleteViewModel
    {
        [Display(Name = "Име")]
        public string Name { get; set; }
        [Display(Name = "Автор")]
        public string Author { get; set; }
        [Display(Name = "Подкатегория")]
        public string SubcategoryName { get; set; }
        [Display(Name = "Категория")]
        public string CategoryName { get; set; }
        [Display(Name = "Група")]
        public string GroupName { get; set; }
        [Display(Name = "Брой въпроси")]
        public int QuestionNumber { get; set; }
    }
}