using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyIt.Web.ViewModels
{
    public class AdminGroupIndexViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name = "Име")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Създател")]
        public string OwnerName { get; set; }
        [Required]
        [Display(Name = "Тип")]
        public GroupType Type { get; set; }

    }
    public class AdminGroupCreateViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name = "Име")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Създател")]
        public int OwnerId { get; set; }
        [Required]
        [Display(Name = "Тип")]
        public GroupType Type { get; set; }
        public SelectList Users { get; set; }
    }
}