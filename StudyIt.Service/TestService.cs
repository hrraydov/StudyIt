using StudyIt.Data;
using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Service
{
    public interface ITestService
    {
        Test GetTest(int testId);
        void CreateTest(Test test);
        void EditTest(Test test);
        void DeleteTest(int testId);
        List<Test> GetTestsByAuthorId(int authorId);
        List<Test> GetTestsBySubcategoryId(int subcategoryId);
        List<int> GetTrueAnswers(int testId);
        List<Question> GetQuestionsByTestId(int testId);
    }
    public class TestService : ITestService
    {
        private ITestRepository testRepo;

        public TestService()
        {
            this.testRepo = new TestRepository(new StudyItContext());
        }

        public TestService(ITestRepository testRepo)
        {
            this.testRepo = testRepo;
        }

        /// <summary>
        /// Get test by given id
        /// </summary>
        /// <param name="testId">The id of a test</param>
        /// <returns></returns>
        public Test GetTest(int testId)
        {
            return testRepo.Get(testId);
        }

        /// <summary>
        /// Creates test
        /// </summary>
        /// <param name="test">The test to be created</param>
        public void CreateTest(Test test)
        {
            testRepo.Add(test);
            testRepo.Save();
        }

        /// <summary>
        /// Gets all tests by id of an author
        /// </summary>
        /// <param name="authorId">The id of the author</param>
        /// <returns></returns>
        public List<Test> GetTestsByAuthorId(int authorId)
        {
            return testRepo.GetAll().Where(x => x.Author.UserId == authorId).ToList();
        }

        /// <summary>
        /// Edits test
        /// </summary>
        /// <param name="test">The test to be edited</param>
        public void EditTest(Test test)
        {
            testRepo.Update(test);
            testRepo.Save();
        }

        /// <summary>
        /// Deletes test by given id
        /// </summary>
        /// <param name="testId">The id of the test to be deleted</param>
        public void DeleteTest(int testId)
        {
            testRepo.Delete(testId);
            testRepo.Save();
        }

        /// <summary>
        /// Get all tests by given id of subcategory
        /// </summary>
        /// <param name="subcategoryId">The id of subcategory</param>
        /// <returns></returns>
        public List<Test> GetTestsBySubcategoryId(int subcategoryId)
        {
            return testRepo.GetAll().Where(x => x.Subcategory.Id == subcategoryId).ToList();
        }

        /// <summary>
        /// Gets the true answers by given id of a test
        /// </summary>
        /// <param name="testId">The id of a test</param>
        /// <returns></returns>
        public List<int> GetTrueAnswers(int testId)
        {
            var test = this.GetTest(testId);
            var questions = test.Questions.ToList();
            var result = new List<int>();
            foreach (var question in questions)
            {
                result.Add(question.Answer);
            }
            return result;
        }

        /// <summary>
        /// Gets all questions by given id of a test
        /// </summary>
        /// <param name="testId">The id of a test</param>
        /// <returns></returns>
        public List<Question> GetQuestionsByTestId(int testId)
        {
            return this.testRepo.Get(testId).Questions.ToList();
        }
    }
}
