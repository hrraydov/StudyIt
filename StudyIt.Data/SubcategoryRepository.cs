using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Data
{
    public interface ISubcategoryRepository : IRepository<Subcategory> { }
    public class SubcategoryRepository : Repository<Subcategory>, ISubcategoryRepository
    {
        public SubcategoryRepository(DbContext context)
            : base(context)
        {
        }

        public void Delete(int subcategoryId)
        {
            var subcategory = this.Get(subcategoryId);
            var lessons = subcategory.Lessons.ToList();
            var tests = subcategory.Tests.ToList();
            var comments = new List<Comment>();
            var questions = new List<Question>();
            var testResults = new List<TestResult>();

            foreach (var lesson in lessons)
            {
                foreach (var comment in lesson.Comments)
                {
                    comments.Add(comment);
                }
            }

            foreach (var test in tests)
            {
                foreach (var question in test.Questions)
                {
                    questions.Add(question);
                }
            }

            foreach (var test in tests)
            {
                foreach (var result in test.TestResults)
                {
                    testResults.Add(result);
                }
            }

            foreach (var item in questions)
            {
                context.Set<Question>().Remove(item);
            }

            foreach (var item in testResults)
            {
                context.Set<TestResult>().Remove(item);
            }

            foreach (var item in comments)
            {
                context.Set<Comment>().Remove(item);
            }

            foreach (var item in tests)
            {
                context.Set<Test>().Remove(item);
            }

            foreach (var item in lessons)
            {
                context.Set<Lesson>().Remove(item);
            }
            
            context.Set<Subcategory>().Remove(subcategory);
        }
    }
}
