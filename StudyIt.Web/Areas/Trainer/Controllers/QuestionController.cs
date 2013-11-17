using StudyIt.Models;
using StudyIt.Service;
using StudyIt.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyIt.Web.Areas.Trainer.Controllers
{

    [Authorize]
    public class QuestionController : Controller
    {
        private IQuestionService questionService;

        public QuestionController()
        {
            this.questionService = new QuestionService();
        }

        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var question = questionService.GetQuestion(id);
            var viewModel = new TrainerQuestionEditViewModel
            {
                Id = question.Id,
                Answer1 = question.Answer1,
                Answer2 = question.Answer2,
                Answer3 = question.Answer3,
                Answer4 = question.Answer4,
                Name = question.Name,
                TrueAnswer = question.Answer,
                Value = question.Value,
                TestId = question.Test.Id,
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, TrainerQuestionEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var question = new Question
                {
                    Id = viewModel.Id,
                    Answer = viewModel.TrueAnswer,
                    Answer1 = viewModel.Answer1,
                    Answer2 = viewModel.Answer2,
                    Answer3 = viewModel.Answer3,
                    Answer4 = viewModel.Answer4,
                    Name = viewModel.Name,
                    Value = viewModel.Value,
                    TestId = viewModel.TestId,
                };
                questionService.EditQuestion(question);
                return Redirect("/trainer/test/");
            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            var viewModel = new TrainerQuestionCreateViewModel
            {
                TestId = id,
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(TrainerQuestionCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var question = new Question
                {
                    Answer = viewModel.TrueAnswer,
                    Answer1 = viewModel.Answer1,
                    Answer2 = viewModel.Answer2,
                    Answer3 = viewModel.Answer3,
                    Answer4 = viewModel.Answer4,
                    Name = viewModel.Name,
                    TestId = viewModel.TestId,
                    Value = viewModel.Value,
                };
                questionService.CreateQuestion(question);
                return Redirect("/trainer/test/details/" + viewModel.TestId);
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var question = questionService.GetQuestion(id);
            var viewModel = new TrainerQuestionDeleteViewModel
            {
                Id = question.Id,
                Answer1 = question.Answer1,
                Answer2 = question.Answer2,
                Answer3 = question.Answer3,
                Answer4 = question.Answer4,
                Name = question.Name,
                TrueAnswer = question.Answer,
                Value = question.Value,
            };
            return View(viewModel);
        }


        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            questionService.DeleteQuestion(id);
            return Redirect("/trainer/test");
        }

    }
}
