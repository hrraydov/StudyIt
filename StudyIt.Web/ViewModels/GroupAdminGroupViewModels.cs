using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudyIt.Web.ViewModels
{
    public class GroupAdminGroupIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<Category> Categories { get; set; }
    }
    public class GroupAdminGroupCreateViewModel
    {
        [Display(Name="Име")]
        [Required(ErrorMessage = "Въведете име")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Името трябва да е между 2 и 100 символа")]
        public string Name { get; set; }
        [Display(Name = "Тип")]
        public GroupType Type { get; set; }
    }
    public class GroupAdminGroupDeleteViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Име")]
        public string Name { get; set; }
        [Display(Name = "Тип")]
        public string Type { get; set; }
    }
}