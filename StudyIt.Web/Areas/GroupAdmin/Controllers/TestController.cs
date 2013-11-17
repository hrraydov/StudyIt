using StudyIt.Models;
using StudyIt.Service;
using StudyIt.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyIt.Web.Areas.GroupAdmin.Controllers
{
    [Authorize(Roles = "GroupAdmin")]
    public class TestController : Controller
    {
        private ITestService testService;

        public TestController()
        {
            this.testService = new TestService();
        }

        public TestController(ITestService testService, IQuestionService questionService)
        {
            this.testService = testService;
        }

        //
        // GET: /GroupAdmin/Test/Details/5

        [HttpGet]
        public ActionResult Details(int id)
        {
            var test = testService.GetTest(id);
            var viewModel = new GroupAdminTestDetailsViewModel
            {
                Author = test.Author.UserName,
                CategoryName = test.Subcategory.Category.Name,
                GroupName = test.Subcategory.Category.Group.Name,
                Name = test.Name,
                Questions = test.Questions as List<Question>,
                SubcategoryName = test.Subcategory.Name,
            };
            return View(viewModel);
        }

        //
        // GET: /GroupAdmin/Test/Delete/5

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var test = testService.GetTest(id);
            var viewModel = new GroupAdminTestDeleteViewModel
            {
                Author = test.Author.UserName,
                CategoryName = test.Subcategory.Category.Name,
                GroupName = test.Subcategory.Category.Group.Name,
                Name = test.Name,
                SubcategoryName = test.Subcategory.Name,
            };
            return View(viewModel);
        }

        //
        // POST: /GroupAdmin/Test/Delete/5

        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            return Redirect("");
        }
    }
}
