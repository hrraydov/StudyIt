using StudyIt.Service;
using StudyIt.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using StudyIt.Web.Filters;
using StudyIt.Models;
using StudyIt.Web.Helpers;

namespace StudyIt.Web.Areas.GroupAdmin.Controllers
{
    [Authorize(Roles = "GroupAdmin")]
    public class GroupController : Controller
    {
        private IGroupService groupService;
        private ICategoryService categoryService;

        public GroupController()
        {
            this.groupService = new GroupService();
            this.categoryService = new CategoryService();
        }

        public GroupController(IGroupService groupService, ICategoryService categoryService)
        {
            this.groupService = groupService;
            this.categoryService = categoryService;
        }

        //
        // GET: /GroupAdmin/Group/

        [HttpGet]
        [InitializeSimpleMembership]
        public ActionResult Index()
        {
            var groups = groupService.GetGroupsByOwnerId(
                WebSecurity.GetUserId(User.Identity.Name)
                );
            var viewModel = new List<GroupAdminGroupIndexViewModel>();
            foreach (var group in groups)
            {
                viewModel.Add(new GroupAdminGroupIndexViewModel
                {
                    Id = group.Id,
                    Name = group.Name,
                    Type = GroupTypeHelper.GroupTypeToString(group.Type),
                    Categories = categoryService.GetCategoriesByGroupId(group.Id),
                });
            }
            return View(viewModel);
        }

        //
        // GET: /GroupAdmin/Group/Create

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /GroupAdmin/Group/Create

        [InitializeSimpleMembership]
        [HttpPost]
        public ActionResult Create(GroupAdminGroupCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var group = new Group
                {
                    Name = viewModel.Name,
                    OwnerId = WebSecurity.GetUserId(User.Identity.Name),
                    Type = viewModel.Type,
                };
                groupService.CreateGroup(group);
                return Redirect("/GroupAdmin/Group");
            }
            return View(viewModel);
        }

        //
        // GET: /GroupAdmin/Group/Delete/5

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var group = groupService.GetGroup(id);
            var viewModel = new GroupAdminGroupDeleteViewModel
            {
                Id = id,
                Name = group.Name,
                Type = GroupTypeHelper.GroupTypeToString(group.Type),
            };
            return View(viewModel);
        }

        //
        // POST: /GroupAdmin/Group/Delete/5

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            groupService.DeleteGroup(id);
            return Redirect("/GroupAdmin/Group/");
        }
    }
}
