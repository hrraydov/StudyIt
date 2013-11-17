using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyIt.Web.ViewModels
{
    public class GroupAdminCategoryCreateViewModel
    {
        [Required(ErrorMessage = "Въведете име")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Името трябва да е между 2 и 100 символа")]
        [Display(Name = "Име")]
        public string Name { get; set; }
        public string GroupName { get; set; }
        public int GroupId { get; set; }
    }
    public class GroupAdminCategoryDeleteViewModel
    {
        [Display(Name = "Име")]
        public string Name { get; set; }
        public string GroupName { get; set; }
    }
}