using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using StudyIt.Models.Mapping;
using StudyIt.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace StudyIt.Data
{
    public partial class StudyItContext : DbContext
    {
        static StudyItContext()
        {
            Database.SetInitializer<StudyItContext>(null);
        }

        public StudyItContext()
            : base("StudyItContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<GroupQuery> GroupQueries { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<GroupAdminQuery> GroupAdminQueries { get; set; }
        public DbSet<TrainerQuery> TrainerQueries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new QuestionMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new GroupQueryMap());
            modelBuilder.Configurations.Add(new GroupMap());
            modelBuilder.Configurations.Add(new LessonMap());
            modelBuilder.Configurations.Add(new SubcategoryMap());
            modelBuilder.Configurations.Add(new TestResultMap());
            modelBuilder.Configurations.Add(new TestMap());
            modelBuilder.Configurations.Add(new UserProfileMap());
            modelBuilder.Configurations.Add(new GroupAdminQueryMap());
            modelBuilder.Configurations.Add(new TrainerQueryMap());
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
