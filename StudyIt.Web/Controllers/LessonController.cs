using StudyIt.Models;
using StudyIt.Service;
using StudyIt.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyIt.Web.Controllers
{
    public class LessonController : Controller
    {
        private ILessonService lessonService;
        private ISubcategoryService subcategoryService;

        public LessonController()
        {
            this.lessonService = new LessonService();
            this.subcategoryService = new SubcategoryService();
        }

        public LessonController(ILessonService lessonService, ISubcategoryService subcategoryService)
        {
            this.lessonService = lessonService;
            this.subcategoryService = subcategoryService;
        }

        //
        // GET: /lesson/list/{subcategoryId}

        [HttpGet]
        public ActionResult List(int id, int page = 1)
        {
            List<Lesson> lessons = lessonService.GetLessonsBySubcategoryId(id);
            int pages = lessons.Count / 10 + 1;
            lessons = lessons.Skip((page - 1) * 10).Take(10).ToList();
            var viewModel = new List<LessonListViewModel>();
            foreach (var lesson in lessons)
            {
                viewModel.Add(new LessonListViewModel
                {
                    AuthorName = lesson.Author.UserName,
                    CommentsCount = lesson.Comments.Count,
                    CreationDate = lesson.CreationDate,
                    Id = lesson.Id,
                    ShortContent = (lesson.Content.Length > 200 ? lesson.Content.Substring(0, 200) : lesson.Content),
                    Title = lesson.Title,
                });
            }
            ViewData["GroupId"] = subcategoryService.GerGroupOfSubcategory(id).Id;
            ViewData["Pages"] = pages;
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            var lesson = lessonService.GetLesson(id);
            var viewModel = new LessonShowViewModel
            {
                Id = lesson.Id,
                AuthorName = lesson.Author.UserName,
                Comments = lesson.Comments.ToList(),
                Content = lesson.Content,
                CreationDate = lesson.CreationDate,
                Title = lesson.Title
            };
            return View(viewModel);
        }

    }
}
