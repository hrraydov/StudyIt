using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StudyIt.Models.Mapping
{
    public class QuestionMap : EntityTypeConfiguration<Question>
    {
        public QuestionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Answer1)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Answer2)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Answer3)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Answer4)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Value)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Questions");
            this.Property(t => t.Id).HasColumnName("QuestionId");
            this.Property(t => t.Name).HasColumnName("QuestionName");
            this.Property(t => t.Answer).HasColumnName("QuestionAnswer");
            this.Property(t => t.Answer1).HasColumnName("Answer1");
            this.Property(t => t.Answer2).HasColumnName("Answer2");
            this.Property(t => t.Answer3).HasColumnName("Answer3");
            this.Property(t => t.Answer4).HasColumnName("Answer4");
            this.Property(t => t.Value).HasColumnName("QuestionValue");
            this.Property(t => t.TestId).HasColumnName("TestId");

            // Relationships
            this.HasRequired(t => t.Test)
                .WithMany(t => t.Questions)
                .HasForeignKey(d => d.TestId);

        }
    }
}
