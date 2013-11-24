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
    public class MembersController : Controller
    {
        private IGroupService groupService;
        private IGroupQueryService queryService;

        public MembersController()
        {
            this.groupService = new GroupService();
            this.queryService = new GroupQueryService();
        }

        public MembersController(IGroupService groupService, IGroupQueryService queryService)
        {
            this.groupService = groupService;
            this.queryService = queryService;
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            var members = groupService.GetMembersForGroup(id);
            var viewModel = new List<GroupAdminMembersShowViewModel>();
            foreach (var member in members)
            {
                viewModel.Add(new GroupAdminMembersShowViewModel
                {
                    Id = member.UserId,
                    Name = member.UserName,
                    GroupId = id,
                });
            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Delete(int groupId, int memberId)
        {
            groupService.DeleteMember(groupId, memberId);
            return Redirect("/GroupAdmin/");
        }

        [HttpGet]
        public ActionResult Queries(int id)
        {
            var queries = groupService.GetGroupQueries(id);
            var viewModel = new List<GroupAdminMembersQueriesViewModel>();
            foreach (var query in queries)
            {
                viewModel.Add(new GroupAdminMembersQueriesViewModel
                {
                    Id = query.Id,
                    UserName = query.User.UserName,
                    Message = query.Message,
                });
            };
            return View(viewModel);
        }

        public ActionResult Create(int id)
        {
            var query = queryService.GetQuery(id);
            groupService.AddMember(query.Group.Id, query.User.UserId);
            queryService.DeleteQuery(id);
            return Redirect("/GroupAdmin/");
        }

        [HttpGet]
        public ActionResult DeleteQuery(int id)
        {
            this.queryService.DeleteQuery(id);
            return Redirect("/groupadmin/");
        }
    }
}
