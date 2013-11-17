using System;
using System.Collections.Generic;

namespace StudyIt.Models
{
    public partial class Test
    {
        public Test()
        {
            this.Questions = new List<Question>();
            this.TestResults = new List<TestResult>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool ShowTrueAnswers { get; set; }
        public int AuthorId { get; set; }
        public int SubcategoryId { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual Subcategory Subcategory { get; set; }
        public virtual ICollection<TestResult> TestResults { get; set; }
        public virtual UserProfile Author { get; set; }
    }
}
