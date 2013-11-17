using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Models.Mapping
{
    public class TrainerQueryMap : EntityTypeConfiguration<TrainerQuery>
    {
        public TrainerQueryMap()
        {
            //Primary key
            this.HasKey(t => t.Id);

            //Table & Column Mappings
            this.ToTable("TrainerQueries");

            this.HasRequired(t => t.User)
                .WithMany(t => t.TrainerQueries)
                .HasForeignKey(d => d.UserId);

            this.HasRequired(t => t.Group)
                .WithMany(t => t.TrainerQueries)
                .HasForeignKey(d => d.GroupId);
        }
    }
}
