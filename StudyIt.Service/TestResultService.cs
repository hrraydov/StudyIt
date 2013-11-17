using StudyIt.Data;
using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Service
{
    public interface ITestResultService
    {
        void Create(TestResult result);
        List<TestResult> GetResultsByUserId(int userId);
        List<TestResult> GetResultsByTestId(int testId);
        List<TestResult> GetResultsByTrainerId(int trainerId);
    }
    public class TestResultService : ITestResultService
    {
        private ITestResultRepository testResultRepo;
        private ITestRepository testRepo;

        public TestResultService()
        {
            var context = new StudyItContext();
            this.testResultRepo = new TestResultRepository(context);
            this.testRepo = new TestRepository(context);
        }

        public TestResultService(ITestResultRepository testResultRepo, ITestRepository testRepo)
        {
            this.testResultRepo = testResultRepo;
            this.testRepo = testRepo;
        }

        /// <summary>
        /// Creates test result
        /// </summary>
        /// <param name="result">The test result to be created</param>
        public void Create(TestResult result)
        {
            this.testResultRepo.Add(result);
            this.testResultRepo.Save();
        }

        /// <summary>
        /// Gets results by given id of a user
        /// </summary>
        /// <param name="userId">The id of a user</param>
        /// <returns></returns>
        public List<TestResult> GetResultsByUserId(int userId)
        {
            return this.testResultRepo.GetAll().Where(x => x.User.UserId == userId).ToList();
        }

        /// <summary>
        /// Gets result by given id of a test
        /// </summary>
        /// <param name="testId">The id of a test</param>
        /// <returns></returns>
        public List<TestResult> GetResultsByTestId(int testId)
        {
            return this.testResultRepo.GetAll().Where(x => x.Test.Id == testId).ToList();
        }

        /// <summary>
        /// Gets result by given id of a trainer
        /// </summary>
        /// <param name="trainerId">The id of a trainer</param>
        /// <returns></returns>
        public List<TestResult> GetResultsByTrainerId(int trainerId)
        {
            var results = new List<TestResult>();
            var tests = this.testRepo.GetAll().Where(x => x.Author.UserId == trainerId).ToList();
            foreach (var test in tests)
            {
                foreach (var result in this.GetResultsByTestId(test.Id))
                {
                    results.Add(result);
                }
            }
            return results;
        }
    }
}
