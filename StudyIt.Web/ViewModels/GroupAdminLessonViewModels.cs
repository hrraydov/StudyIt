using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudyIt.Web.ViewModels
{
    public class GroupAdminLessonDetailsViewModel
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

    public class GroupAdminLessonDeleteViewModel
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