using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Models
{
    public class TrainerQuery
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }

        public virtual UserProfile User { get; set; }
        public virtual Group Group { get; set; }

    }
}
