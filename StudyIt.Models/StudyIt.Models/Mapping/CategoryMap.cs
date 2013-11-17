using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StudyIt.Models.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Categories");
            this.Property(t => t.Id).HasColumnName("CategoryId");
            this.Property(t => t.Name).HasColumnName("CategoryName");
            this.Property(t => t.GroupId).HasColumnName("GroupId");

            // Relationships
            this.HasRequired(t => t.Group)
                .WithMany(t => t.Categories)
                .HasForeignKey(d => d.GroupId);

        }
    }
}
