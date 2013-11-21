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
    public class TestResultController : Controller
    {
        private ITestResultService testResultService;

        public TestResultController()
        {
            this.testResultService = new TestResultService();
        }

        public TestResultController(ITestResultService testResultService)
        {
            this.testResultService = testResultService;
        }

        public ActionResult Show()
        {
            var score = 0;
            var totalScore = 0;
            var results = this.testResultService.GetResultsByUserId((int)Membership.GetUser().ProviderUserKey);
            var viewModel = new List<TestResultsShowViewModel>();
            foreach (var result in results)
            {
                viewModel.Add(new TestResultsShowViewModel
                {
                    Name = result.Test.Name,
                    Score = result.Value,
                    TotalScore = result.TotalScore,
                });
                score += result.Value;
                totalScore += result.TotalScore;
            }
            ViewData["score"] = score;
            ViewData["totalScore"] = totalScore;
            return View("~/Views/Test/Results.cshtml",viewModel);
        }

    }
}
