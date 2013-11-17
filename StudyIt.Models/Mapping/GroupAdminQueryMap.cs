using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Models.Mapping
{
    public class GroupAdminQueryMap : EntityTypeConfiguration<GroupAdminQuery>
    {
        public GroupAdminQueryMap()
        {
            //Primary key
            this.HasKey(t => t.Id);

            //Table & Column Mappings
            this.ToTable("GroupAdminQueries");

            this.HasRequired(t => t.User)
                .WithMany(t => t.GroupAdminQueries)
                .HasForeignKey(d => d.UserId);
        }
    }
}
