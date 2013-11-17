using System;
using System.Collections.Generic;

namespace StudyIt.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public DateTime CreationDate { get; set; }
        public int AuthorId { get; set; }
        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }
        public virtual UserProfile Author { get; set; }
    }
}
