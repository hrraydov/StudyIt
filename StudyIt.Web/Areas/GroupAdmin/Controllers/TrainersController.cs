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
    public class TrainersController : Controller
    {
        private IGroupService groupService;
        private ITrainerQueryService queryService;

        public TrainersController()
        {
            this.groupService = new GroupService();
            this.queryService = new TrainerQueryService();
        }

        public TrainersController(IGroupService groupService, ITrainerQueryService queryService)
        {
            this.groupService = groupService;
            this.queryService = queryService;
        }
        
        [HttpGet]
        public ActionResult Show(int id)
        {
            var trainers = groupService.GetTrainersForGroup(id);
            var viewModel = new List<GroupAdminTrainersShowViewModel>();
            foreach (var trainer in trainers)
            {
                viewModel.Add(new GroupAdminTrainersShowViewModel
                {
                    Id = trainer.UserId,
                    Name = trainer.UserName,
                    GroupId = id,
                });
            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Delete(int groupId, int trainerId)
        {
            groupService.DeleteTrainer(groupId, trainerId);
            return Redirect("/GroupAdmin/");
        }

        [HttpGet]
        public ActionResult Queries(int id)
        {
            var queries = groupService.GetTrainerQueries(id);
            var viewModel = new List<GroupAdminTrainersQueriesViewModel>();
            foreach (var query in queries)
            {
                viewModel.Add(new GroupAdminTrainersQueriesViewModel
                {
                    Id = query.Id,
                    UserName = query.User.UserName,
                    Message = query.Content,
                });
            };
            return View(viewModel);
        }

        public ActionResult Create(int id)
        {
            var query = queryService.GetQuery(id);
            groupService.AddTrainer(query.Group.Id, query.User.UserId);
            queryService.DeleteQuery(id);
            return Redirect("/GroupAdmin/");
        }


    }
}
