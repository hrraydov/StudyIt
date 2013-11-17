using System;
using System.Collections.Generic;

namespace StudyIt.Models
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            this.Comments = new List<Comment>();
            this.GroupQueries = new List<GroupQuery>();
            this.Groups = new List<Group>();
            this.Lessons = new List<Lesson>();
            this.TestResults = new List<TestResult>();
            this.Tests = new List<Test>();
            this.MemberOf = new List<Group>();
            this.TrainerOf = new List<Group>();
            this.GroupAdminQueries = new List<GroupAdminQuery>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<GroupQuery> GroupQueries { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<TestResult> TestResults { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
        public virtual ICollection<Group> MemberOf { get; set; }
        public virtual ICollection<Group> TrainerOf { get; set; }
        public virtual ICollection<TrainerQuery> TrainerQueries { get; set; }
        public virtual ICollection<GroupAdminQuery> GroupAdminQueries { get; set; }
    }
}
