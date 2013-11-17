using System;
using System.Collections.Generic;

namespace StudyIt.Models
{
    public partial class TestResult
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int TotalScore { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }
        public virtual Test Test { get; set; }
        public virtual UserProfile User { get; set; }
    }
}
