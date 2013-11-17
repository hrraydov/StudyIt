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
    public class MembersController : Controller
    {
        private IGroupQueryService queryService;

        public MembersController()
        {
            this.queryService = new GroupQueryService();
        }

        public MembersController(IGroupQueryService queryService)
        {
            this.queryService = queryService;
        }

        [HttpGet]
        public ActionResult Become(int id)
        {
            var viewModel = new MembersBecomeViewModel
            {
                GroupId = id,
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Become(MembersBecomeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                queryService.CreateQuery(new GroupQuery
                {
                    GroupId = viewModel.GroupId,
                    Message = viewModel.Message,
                    UserId = (int)Membership.GetUser().ProviderUserKey,
                });
                return Redirect("/groups/not-member-of/");
            }
            return View(viewModel);
        }

    }
}
