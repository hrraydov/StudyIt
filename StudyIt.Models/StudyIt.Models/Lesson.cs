using System;
using System.Collections.Generic;

namespace StudyIt.Models
{
    public partial class Lesson
    {
        public Lesson()
        {
            this.Comments = new List<Comment>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public DateTime CreationDate { get; set; }
        public int SubcategoryId { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Subcategory Subcategory { get; set; }
        public virtual UserProfile Author { get; set; }
    }
}
