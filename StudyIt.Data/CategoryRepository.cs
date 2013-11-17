using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Data
{
    public interface ICategoryRepository : IRepository<Category> { }
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context)
            : base(context)
        {
        }

        public void Delete(int categoryId)
        {
            var category = this.Get(categoryId);
            var subcategories = category.Subcategories.ToList();
            var lessons = new List<Lesson>();
            var tests = new List<Test>();
            var comments = new List<Comment>();
            var questions = new List<Question>();
            var testResults = new List<TestResult>();

            foreach (var subcategory in subcategories)
            {
                foreach (var lesson in subcategory.Lessons)
                {
                    lessons.Add(lesson);
                }
            }

            foreach (var subcategory in subcategories)
            {
                foreach (var test in subcategory.Tests)
                {
                    tests.Add(test);
                }
            }

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

            foreach (var item in subcategories)
            {
                context.Set<Subcategory>().Remove(item);
            }

            context.Set<Category>().Remove(category);
        }
    }
}
