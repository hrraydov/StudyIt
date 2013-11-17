using StudyIt.Service;
using StudyIt.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudyIt.Web.Areas.Trainer.Controllers
{

    [Authorize]
    public class TestsResultsController : Controller
    {

        private ITestResultService testResultService;

        public TestsResultsController()
        {
            this.testResultService = new TestResultService();
        }

        public TestsResultsController(ITestResultService testResultService)
        {
            this.testResultService = testResultService;
        }

        //
        // GET: /Trainer/TestsResults/

        public ActionResult Show(int id)
        {
            var results = this.testResultService.GetResultsByTrainerId((int)Membership.GetUser().ProviderUserKey);
            var viewModel = new List<TrainerTestResultsShowViewModel>();
            foreach (var result in results)
            {
                viewModel.Add(new TrainerTestResultsShowViewModel
                {
                    Name = result.Test.Name,
                    Score = result.Value,
                    TotalScore = result.TotalScore,
                    Username = result.User.UserName,
                });
            }
            return View(viewModel);
        }

    }
}
