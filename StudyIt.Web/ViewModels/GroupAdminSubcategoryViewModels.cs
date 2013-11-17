using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudyIt.Web.ViewModels
{
    public class GroupAdminSubcategoryCreateViewModel
    {
        [Required(ErrorMessage = "Въведете име")]
        [Display(Name = "Име")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Името трябва да е между 2 и 100 символа")]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string GroupName { get; set; }
    }

    public class GroupAdminSubcategoryDeleteViewModel
    {
        [Required(ErrorMessage = "Въведете име")]
        [Display(Name = "Име")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Името трябва да е между 2 и 100 символа")]
        public string Name { get; set; }
        [Display(Name = "Категория")]
        public string CategoryName { get; set; }
        [Display(Name = "Група")]
        public string GroupName { get; set; }
    }
}