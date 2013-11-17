using StudyIt.Service;
using StudyIt.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudyIt.Web.Areas.Admin.Controllers
{
    [Authorize(Roles="Admin")]
    public class GroupAdminsController : Controller
    {
        private IGroupAdminQueryService queryService;

        public GroupAdminsController()
        {
            this.queryService = new GroupAdminQueryService();
        }

        public GroupAdminsController(IGroupAdminQueryService queryService)
        {
            this.queryService = queryService;
        }

        //
        // Admin/GroupAdmins/Show

        [HttpGet]
        public ActionResult Show()
        {
            var userNames = Roles.GetUsersInRole("GroupAdmin").ToList();
            var viewModel = new List<AdminGroupAdminsShowViewModel>();
            foreach (var username in userNames)
            {
                viewModel.Add(new AdminGroupAdminsShowViewModel
                {
                    Id = (int)Membership.GetUser(username).ProviderUserKey,
                    Name = username,
                });
            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Roles.RemoveUserFromRole((string)Membership.GetUser(id).ProviderName, "GroupAdmin");
            return Redirect("/admin/groupadmins/show");
        }

        [HttpGet]
        public ActionResult Queries()
        {
            var queries = queryService.GetQueries();
            var viewModel = new List<AdminGroupAdminsQueriesViewModel>();
            foreach (var query in queries)
            {
                viewModel.Add(new AdminGroupAdminsQueriesViewModel
                {
                    Id = query.Id,
                    Name = query.User.UserName,
                    Message = query.Content,
                });
            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            var query = queryService.GetQuery(id);
            Roles.AddUserToRole(query.User.UserName, "GroupAdmin");
            this.queryService.DeleteQuery(id);
            return Redirect("/admin/groupadmin/queries");
        }

    }
}
