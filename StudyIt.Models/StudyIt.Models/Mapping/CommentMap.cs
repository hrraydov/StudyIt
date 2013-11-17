using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StudyIt.Models.Mapping
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Desc)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Comments");
            this.Property(t => t.Id).HasColumnName("CommentId");
            this.Property(t => t.Desc).HasColumnName("ComentDesc");
            this.Property(t => t.CreationDate).HasColumnName("CommentCreationDate");
            this.Property(t => t.AuthorId).HasColumnName("AuthorId");
            this.Property(t => t.LessonId).HasColumnName("LessonId");

            // Relationships
            this.HasRequired(t => t.Lesson)
                .WithMany(t => t.Comments)
                .HasForeignKey(d => d.LessonId);
            this.HasRequired(t => t.Author)
                .WithMany(t => t.Comments)
                .HasForeignKey(d => d.AuthorId);

        }
    }
}
