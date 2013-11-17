using StudyIt.Models;
using StudyIt.Service;
using StudyIt.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudyIt.Web.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        private ISubcategoryService subcategoryService;
        private ITestService testService;
        private ITestResultService testResultService;

        public TestController()
        {
            this.subcategoryService = new SubcategoryService();
            this.testService = new TestService();
            this.testResultService = new TestResultService();
        }

        public TestController(ITestService testService, ITestResultService testResultService, ISubcategoryService subcategoryService)
        {
            this.subcategoryService = subcategoryService;
            this.testService = testService;
            this.testResultService = testResultService;
        }

        public ActionResult List(int id)
        {
            var tests = testService.GetTestsBySubcategoryId(id);
            var viewModel = new List<TestListViewModel>();
            foreach (var test in tests)
            {
                viewModel.Add(new TestListViewModel
                {
                    Id = test.Id,
                    Name = test.Name,
                });
            }
            ViewData["GroupId"] = this.subcategoryService.GerGroupOfSubcategory(id).Id;
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Do(int id)
        {
            var test = testService.GetTest(id);
            var viewModel = new TestDoViewModel
            {
                Name = test.Name,
                Id = test.Id,
                Questions = test.Questions.ToList(),
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Do(TestDoViewModel viewModel)
        {
            Dictionary<int, int> givenAnswers = new Dictionary<int, int>();
            List<Question> wrongQuestions = new List<Question>();
            int questionNumber = 0;
            int result = 0;
            int maxResult = 0;
            var questions = testService.GetQuestionsByTestId(viewModel.Id);
            var test = testService.GetTest(viewModel.Id);
            foreach (var questionId in viewModel.QuestionIds)
            {
                var question = questions.Where(x => x.Id == questionId).First();
                var answer = viewModel.Answers[questionNumber];
                if (answer == question.Answer)
                {
                    result += question.Value;
                }
                else
                {
                    givenAnswers[questionId] = answer;
                    wrongQuestions.Add(question);
                }
                maxResult += question.Value;
                questionNumber++;
            }
            var returnViewModel = new TestShowResultViewModel
            {
                GivenAnswers = givenAnswers,
                Name = viewModel.Name,
                TotalScore = maxResult,
                Value = result,
                WrongQuestions = wrongQuestions,
                ShowTrueAnswers = test.ShowTrueAnswers,
            };
            testResultService.Create(new TestResult
            {
                TestId = viewModel.Id,
                TotalScore = maxResult,
                UserId = ((int)Membership.GetUser().ProviderUserKey),
                Value = result,
            });
            return View("ShowResult", returnViewModel);
        }

    }
}
