using StudyIt.Service;
using StudyIt.Web.ViewModels;
using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudyIt.Web.Controllers
{
    [Authorize]
    public class GroupAdminController : Controller
    {
        private IGroupAdminQueryService queryService;

        public GroupAdminController()
        {
            this.queryService = new GroupAdminQueryService();
        }

        public GroupAdminController(IGroupAdminQueryService queryService)
        {
            this.queryService = queryService;
        }

        [HttpGet]
        public ActionResult Become()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Become(GroupAdminBecomeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                queryService.CreateQuery(new GroupAdminQuery
                {
                    Content = viewModel.Message,
                    UserId = (int)Membership.GetUser().ProviderUserKey,
                });
            }
            return View(viewModel);
        }

    }
}
