using System;
using System.Collections.Generic;

namespace StudyIt.Models
{
    public partial class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Answer { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public int Value { get; set; }
        public int TestId { get; set; }
        public virtual Test Test { get; set; }
    }
}
