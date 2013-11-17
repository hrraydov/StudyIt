using System;
using System.Collections.Generic;

namespace StudyIt.Models
{
    public partial class GroupQuery
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public string Message { get; set; }
        public virtual Group Group { get; set; }
        public virtual UserProfile User { get; set; }
    }
}
