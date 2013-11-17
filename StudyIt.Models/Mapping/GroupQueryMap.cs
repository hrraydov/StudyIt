using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StudyIt.Models.Mapping
{
    public class GroupQueryMap : EntityTypeConfiguration<GroupQuery>
    {
        public GroupQueryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Message)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("GroupQueries");
            this.Property(t => t.Id).HasColumnName("QueryId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.GroupId).HasColumnName("GroupId");
            this.Property(t => t.Message).HasColumnName("QueryMessage");

            // Relationships
            this.HasRequired(t => t.Group)
                .WithMany(t => t.Queries)
                .HasForeignKey(d => d.GroupId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.GroupQueries)
                .HasForeignKey(d => d.UserId);

        }
    }
}
