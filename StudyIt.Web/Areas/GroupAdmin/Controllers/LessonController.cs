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
    [Authorize(Roles = "GroupAdmin,Admin")]
    public class LessonController : Controller
    {
        private ILessonService lessonService;

        public LessonController()
        {
            this.lessonService = new LessonService();
        }

        public LessonController(ILessonService lessonService)
        {
            this.lessonService = lessonService;
        }

        //
        // GET: /GroupAdmin/Lesson/Details/5

        [HttpGet]
        public ActionResult Details(int id)
        {
            var lesson = lessonService.GetLesson(id);
            var viewModel = new GroupAdminLessonDetailsViewModel
            {
                Author = lesson.Author.UserName,
                CategoryName = lesson.Subcategory.Category.Name,
                Content = lesson.Content,
                CreationDate = lesson.CreationDate,
                GroupName = lesson.Subcategory.Category.Group.Name,
                SubcategoryName = lesson.Subcategory.Name,
                Title = lesson.Title,
            };
            return View(viewModel);
        }

        //
        // GET: /GroupAdmin/Lesson/Delete/5

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var lesson = lessonService.GetLesson(id);
            var viewModel = new GroupAdminLessonDeleteViewModel
            {
                Author = lesson.Author.UserName,
                CategoryName = lesson.Subcategory.Category.Name,
                CreationDate = lesson.CreationDate,
                GroupName = lesson.Subcategory.Category.Group.Name,
                SubcategoryName = lesson.Subcategory.Name,
                Title = lesson.Title,
            };
            return View(viewModel);
        }

        //
        // POST: /GroupAdmin/Lesson/Delete/5

        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            lessonService.DeleteLesson(id);
            return Redirect("/GroupAdmin/");
        }
    }
}
