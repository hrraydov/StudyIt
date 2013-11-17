using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StudyIt.Models.Mapping
{
    public class SubcategoryMap : EntityTypeConfiguration<Subcategory>
    {
        public SubcategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Subcategories");
            this.Property(t => t.Id).HasColumnName("SubcategoryId");
            this.Property(t => t.Name).HasColumnName("SubcategoryName");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");

            // Relationships
            this.HasRequired(t => t.Category)
                .WithMany(t => t.Subcategories)
                .HasForeignKey(d => d.CategoryId);

        }
    }
}
