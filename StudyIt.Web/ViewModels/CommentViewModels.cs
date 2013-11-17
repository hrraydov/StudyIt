using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyIt.Web.ViewModels
{
    public class CommentCreateViewModel
    {
        public string Desc { get; set; }
        public int LessonId { get; set; }
    }
}