using System;
using System.Collections.Generic;

namespace StudyIt.Models
{
    public partial class Subcategory
    {
        public Subcategory()
        {
            this.Lessons = new List<Lesson>();
            this.Tests = new List<Test>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
}
