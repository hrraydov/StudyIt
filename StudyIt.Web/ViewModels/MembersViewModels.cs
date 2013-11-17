using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudyIt.Web.ViewModels
{
    public class MembersBecomeViewModel
    {
        [Required]
        public int GroupId { get; set; }
        [Display(Name = "Съобщение")]
        [Required]
        [StringLength(500, ErrorMessage = "Съобщението трябва да е под 500 символа")]
        public string Message { get; set; }
    }
}