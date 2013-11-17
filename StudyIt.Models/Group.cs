using System;
using System.Collections.Generic;

namespace StudyIt.Models
{
    public partial class Group
    {
        public Group()
        {
            this.Categories = new List<Category>();
            this.Queries = new List<GroupQuery>();
            this.Members = new List<UserProfile>();
            this.Trainers = new List<UserProfile>();
            this.TrainerQueries = new List<TrainerQuery>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public GroupType Type { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<GroupQuery> Queries { get; set; }
        public virtual UserProfile Owner { get; set; }
        public virtual ICollection<UserProfile> Members { get; set; }
        public virtual ICollection<UserProfile> Trainers { get; set; }
        public virtual ICollection<TrainerQuery> TrainerQueries { get; set; }
    }
}
