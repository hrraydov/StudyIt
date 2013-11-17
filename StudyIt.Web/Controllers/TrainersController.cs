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
    public class TrainersController : Controller
    {
        private ITrainerQueryService trainerQueryService;

        public TrainersController()
        {
            this.trainerQueryService = new TrainerQueryService();
        }

        public TrainersController(ITrainerQueryService trainerQueryService)
        {
            this.trainerQueryService = trainerQueryService;
        }

        [HttpGet]
        public ActionResult Become(int id)
        {
            var viewModel = new TrainersBecomeViewModel
            {
                GroupId = id,
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Become(TrainersBecomeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                trainerQueryService.CreateQuery(new TrainerQuery
                {
                    Content = viewModel.Message,
                    GroupId = viewModel.GroupId,
                    UserId = (int)Membership.GetUser().ProviderUserKey,
                });
                return Redirect("/groups/member-of/");
            }
            return View(viewModel);
        }

    }
}
