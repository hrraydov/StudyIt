using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StudyIt.Models.Mapping
{
    public class GroupMap : EntityTypeConfiguration<Group>
    {
        public GroupMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Groups");
            this.Property(t => t.Id).HasColumnName("GroupId");
            this.Property(t => t.Name).HasColumnName("GroupName");
            this.Property(t => t.OwnerId).HasColumnName("OwnerId");

            // Relationships
            this.HasMany(t => t.Members)
                .WithMany(t => t.MemberOf)
                .Map(m =>
                    {
                        m.ToTable("GroupMembers");
                        m.MapLeftKey("GroupId");
                        m.MapRightKey("UserId");
                    });

            this.HasRequired(t => t.Owner)
                .WithMany(t => t.Groups)
                .HasForeignKey(d => d.OwnerId);

            this.HasMany(t => t.Trainers)
                .WithMany(t => t.TrainerOf)
                .Map(m =>
                {
                    m.ToTable("GroupTrainers");
                    m.MapLeftKey("GroupId");
                    m.MapRightKey("TrainerId");
                });

        }
    }
}
