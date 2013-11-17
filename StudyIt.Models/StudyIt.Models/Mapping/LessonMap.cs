using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StudyIt.Models.Mapping
{
    public class LessonMap : EntityTypeConfiguration<Lesson>
    {
        public LessonMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Content)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Lessons");
            this.Property(t => t.Id).HasColumnName("LessonId");
            this.Property(t => t.Title).HasColumnName("LessonTitle");
            this.Property(t => t.Content).HasColumnName("LessonContent");
            this.Property(t => t.AuthorId).HasColumnName("AuthorId");
            this.Property(t => t.CreationDate).HasColumnName("CreationDate");
            this.Property(t => t.SubcategoryId).HasColumnName("SubcategoryId");

            // Relationships
            this.HasRequired(t => t.Subcategory)
                .WithMany(t => t.Lessons)
                .HasForeignKey(d => d.SubcategoryId);
            this.HasRequired(t => t.Author)
                .WithMany(t => t.Lessons)
                .HasForeignKey(d => d.AuthorId);

        }
    }
}
