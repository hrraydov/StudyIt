using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StudyIt.Models.Mapping
{
    public class TestMap : EntityTypeConfiguration<Test>
    {
        public TestMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.ShowTrueAnswers)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Tests");
            this.Property(t => t.Id).HasColumnName("TestId");
            this.Property(t => t.Name).HasColumnName("TestName");
            this.Property(t => t.AuthorId).HasColumnName("AuthorId");
            this.Property(t => t.SubcategoryId).HasColumnName("SubcategoryId");

            // Relationships
            this.HasRequired(t => t.Subcategory)
                .WithMany(t => t.Tests)
                .HasForeignKey(d => d.SubcategoryId);
            this.HasRequired(t => t.Author)
                .WithMany(t => t.Tests)
                .HasForeignKey(d => d.AuthorId);

        }
    }
}
