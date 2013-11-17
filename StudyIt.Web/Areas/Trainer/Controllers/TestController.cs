using StudyIt.Models;
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
    public class TestController : Controller
    {
        private ITestService testService;
        private IGroupService groupService;

        public TestController()
        {
            this.testService = new TestService();
            this.groupService = new GroupService();
        }

        public TestController(ITestService testService, IGroupService groupService)
        {
            this.testService = testService;
            this.groupService = groupService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var tests = testService.GetTestsByAuthorId((int)Membership.GetUser().ProviderUserKey);
            var viewModel = new List<TrainerTestIndexViewModel>();
            foreach (var test in tests)
            {
                viewModel.Add(new TrainerTestIndexViewModel
                {
                    Id = test.Id,
                    Name = test.Name,
                    Category = test.Subcategory.Category.Name,
                    Subcategory = test.Subcategory.Name,
                    Group = test.Subcategory.Category.Group.Name,
                    QuestionNumber = test.Questions.ToList().Count
                });
            }
            return View(viewModel);
        }

        public ActionResult Create()
        {
            var userId = (int)Membership.GetUser().ProviderUserKey;
            var groups = groupService.GetGroupsByTrainerId(userId);
            var viewModel = new TrainerTestCreateViewModel
            {
                Groups = new SelectList(groups, "Id", "Name"),
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(TrainerTestCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var test = new Test
                {
                    Name = viewModel.Name,
                    AuthorId = (int)Membership.GetUser().ProviderUserKey,
                    ShowTrueAnswers = viewModel.ShowTrueAnswers,
                    SubcategoryId = viewModel.SubcategoryId,
                };
                testService.CreateTest(test);
                return Redirect("/trainer/test");
            }

            var userId = (int)Membership.GetUser().ProviderUserKey;
            var groups = groupService.GetGroupsByTrainerId(userId);
            viewModel.Groups = new SelectList(groups, "Id", "Name");
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var test = testService.GetTest(id);
            var viewModel = new TrainerTestDetailsViewModel
            {
                Id = test.Id,
                Author = test.Author.UserName,
                CategoryName = test.Subcategory.Category.Name,
                GroupName = test.Subcategory.Category.Group.Name,
                SubcategoryName = test.Subcategory.Name,
                Name = test.Name,
                QuestionNumber = test.Questions.ToList().Count,
                Questions = test.Questions.ToList(),
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var test = testService.GetTest(id);
            var viewModel = new TrainerTestEditViewModel
            {
                Id = test.Id,
                Name = test.Name,
            };
            return View(viewModel);
        }

        //
        // POST: /Trainer/Lesson/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, TrainerTestEditViewModel viewModel)
        {
            if (viewModel.Id == id)
            {
                if (ModelState.IsValid)
                {
                    var test = new Test
                    {
                        Id = viewModel.Id,
                        Name = viewModel.Name,
                    };
                    testService.EditTest(test);
                    return Redirect("/trainer/test");
                }
                return View(viewModel);
            }
            else
            {
                throw new Exception("Dont do this");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var test = testService.GetTest(id);
            var viewModel = new TrainerTestDeleteViewModel
            {
                Author = test.Author.UserName,
                CategoryName = test.Subcategory.Category.Name,
                GroupName = test.Subcategory.Category.Group.Name,
                SubcategoryName = test.Subcategory.Name,
                Name = test.Name,
            };
            return View(viewModel);
        }


        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            testService.DeleteTest(id);
            return Redirect("/trainer/test");
        }
    }
}
