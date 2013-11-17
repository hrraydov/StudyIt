using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyIt.Models;
using System.Collections.Generic;
using StudyIt.Web.Tests.FakeRepositories;
using StudyIt.Service;
using StudyIt.Web.Controllers;
using System.Web.Mvc;
using StudyIt.Web.ViewModels;

namespace StudyIt.Web.Tests.Controllers
{
    [TestClass]
    public class LessonControllerTest
    {
        
        [TestMethod]
        public void Show()
        {
            List<Lesson> lessons = new List<Lesson>();
            lessons.Add(new Lesson
            {
                Id = 1,
                Author = new UserProfile
                {
                    UserId = 1,
                    UserName = "hrraydov"
                },
                Content = "Content of Lesson 1",
                CreationDate = DateTime.Now,
                Subcategory = new Subcategory
                {
                    Id = 1,
                    Name = "Subcategory 1",
                },
                SubcategoryId = 1,
                Title = "Lesson1",
            });
            FakeLessonRepository lessonRepo = new FakeLessonRepository(lessons);
            LessonService lessonService = new LessonService(lessonRepo);
            LessonController controller = new LessonController(lessonService,new SubcategoryService());
            ViewResult result = controller.Show(1) as ViewResult;
            var viewModel = (LessonShowViewModel)result.Model;

            Assert.AreEqual(result.ViewName, "");
        }
    }
}
