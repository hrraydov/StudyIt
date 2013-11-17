using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StudyIt.Models.Mapping
{
    public class TestResultMap : EntityTypeConfiguration<TestResult>
    {
        public TestResultMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TestResults");
            this.Property(t => t.Id).HasColumnName("ResultId");
            this.Property(t => t.Value).HasColumnName("ResultValue");
            this.Property(t => t.TotalScore).HasColumnName("ResultTotalScore");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.TestId).HasColumnName("TestId");

            // Relationships
            this.HasRequired(t => t.Test)
                .WithMany(t => t.TestResults)
                .HasForeignKey(d => d.TestId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.TestResults)
                .HasForeignKey(d => d.UserId);

        }
    }
}
