using StudyIt.Data;
using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Service
{
    public interface IQuestionService
    {
        List<Question> GetQuestionsByTestId(int testId);
        Question GetQuestion(int questionId);
        void EditQuestion(Question question);
        void CreateQuestion(Question question);
        void DeleteQuestion(int questionId);
    }
    public class QuestionService : IQuestionService
    {
        private IQuestionRepository questionRepo;

        public QuestionService()
        {
            this.questionRepo = new QuestionRepository(new StudyItContext());
        }

        public QuestionService(IQuestionRepository questionRepo)
        {
            this.questionRepo = questionRepo;
        }

        /// <summary>
        /// Gets all questions by given id of test
        /// </summary>
        /// <param name="testId">The id of a test</param>
        /// <returns></returns>
        public List<Question> GetQuestionsByTestId(int testId)
        {
            return questionRepo.GetAll().Where(x => x.Test.Id == testId).ToList();
        }

        /// <summary>
        /// Gets question by given id
        /// </summary>
        /// <param name="questionId">The id of a question</param>
        /// <returns></returns>
        public Question GetQuestion(int questionId)
        {
            return questionRepo.Get(questionId);
        }

        /// <summary>
        /// Edits question
        /// </summary>
        /// <param name="question">The question to be edited</param>
        public void EditQuestion(Question question)
        {
            questionRepo.Update(question);
            questionRepo.Save();
        }

        /// <summary>
        /// Creates question
        /// </summary>
        /// <param name="question">The question to be created</param>
        public void CreateQuestion(Question question)
        {
            questionRepo.Add(question);
            questionRepo.Save();
        }

        /// <summary>
        /// Deleted question
        /// </summary>
        /// <param name="questionId">The id of the question to be deleted</param>
        public void DeleteQuestion(int questionId)
        {
            questionRepo.Delete(questionId);
            questionRepo.Save();
        }
    }
}
