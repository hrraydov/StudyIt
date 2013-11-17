using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Data
{
    public interface ITestRepository : IRepository<Test> { }
    public class TestRepository : Repository<Test>, ITestRepository
    {
        public TestRepository(DbContext context)
            : base(context)
        {
        }

        public void Delete(int testId)
        {
            var test = this.Get(testId);
            var questions = test.Questions.ToList();
            var testResults = test.TestResults.ToList();



            foreach (var item in questions)
            {
                context.Set<Question>().Remove(item);
            }

            foreach (var item in testResults)
            {
                context.Set<TestResult>().Remove(item);
            }

            context.Set<Test>().Remove(test);
        }
    }
}
