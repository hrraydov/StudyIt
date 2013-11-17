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
    public class LessonController : Controller
    {
        private ILessonService lessonService;
        private IGroupService groupService;

        public LessonController()
        {
            this.lessonService = new LessonService();
            this.groupService = new GroupService();
        }

        public LessonController(ILessonService lessonService, IGroupService groupService)
        {
            this.lessonService = lessonService;
            this.groupService = groupService;
        }

        //
        // GET: /Trainer/Lesson/

        [HttpGet]
        public ActionResult Index()
        {
            var lessons = lessonService.GetLessonsByAuthorId((int)Membership.GetUser().ProviderUserKey);
            var viewModel = new List<TrainerLessonIndexViewModel>();
            foreach (var lesson in lessons)
            {
                viewModel.Add(new TrainerLessonIndexViewModel
                {
                    Id = lesson.Id,
                    Title = lesson.Title,
                    Category = lesson.Subcategory.Category.Name,
                    Subcategory = lesson.Subcategory.Name,
                    Group = lesson.Subcategory.Category.Group.Name
                });
            }
            return View(viewModel);
        }

        //
        // GET: /Trainer/Lesson/Details/5

        [HttpGet]
        public ActionResult Details(int id)
        {
            var lesson = lessonService.GetLesson(id);
            var viewModel = new TrainerLessonDetailsViewModel
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
        // GET: /Trainer/Lesson/Create

        [ValidateInput(false)]
        [HttpGet]
        public ActionResult Create()
        {
            var userId = (int)Membership.GetUser().ProviderUserKey;
            var groups = groupService.GetGroupsByTrainerId(userId);
            var viewModel = new TrainerLessonCreateViewModel
            {
                Groups = new SelectList(groups, "Id", "Name"),
            };
            return View(viewModel);
        }

        //
        // POST: /Trainer/Lesson/Create
        
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(TrainerLessonCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var lesson = new Lesson
                {
                    Title = viewModel.Title,
                    AuthorId = (int)Membership.GetUser().ProviderUserKey,
                    Content = viewModel.Content,
                    CreationDate = DateTime.Now,
                    SubcategoryId = viewModel.SubcategoryId,
                };
                lessonService.CreateLesson(lesson);
                return Redirect("/trainer/lesson");
            }

            var userId = (int)Membership.GetUser().ProviderUserKey;
            var groups = groupService.GetGroupsByTrainerId(userId);
            viewModel.Groups = new SelectList(groups, "Id", "Name");
            return View(viewModel);
        }

        //
        // GET: /Trainer/Lesson/Edit/5

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult Edit(int id)
        {
            var lesson = lessonService.GetLesson(id);
            var viewModel = new TrainerLessonEditViewModel
            {
                Content = lesson.Content,
                Id = lesson.Id,
                Title = lesson.Title,
            };
            return View(viewModel);
        }

        //
        // POST: /Trainer/Lesson/Edit/5

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, TrainerLessonEditViewModel viewModel)
        {
            if (viewModel.Id == id)
            {
                if (ModelState.IsValid)
                {
                    var getLesson = lessonService.GetLesson(id);
                    var lesson = new Lesson
                    {
                        Id = viewModel.Id,
                        Title = viewModel.Title,
                        Content = viewModel.Content,
                        CreationDate = getLesson.CreationDate,
                    };
                    lessonService.EditLesson(lesson);
                    return Redirect("/trainer/lesson");
                }
                return View(viewModel);
            }
            else
            {
                throw new Exception("Dont do this");
            }
        }

        //
        // GET: /Trainer/Lesson/Delete/5

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var lesson = lessonService.GetLesson(id);
            var viewModel = new TrainerLessonDeleteViewModel
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
        // POST: /Trainer/Lesson/Delete/5

        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            lessonService.DeleteLesson(id);
            return Redirect("/trainer/lesson");
        }
    }
}
