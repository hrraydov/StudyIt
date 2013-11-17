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
    public class GroupsController : Controller
    {
        private IGroupService groupService;
        private IUserService userService;

        public GroupsController()
        {
            this.groupService = new GroupService();
            this.userService = new UserService();
        }

        public GroupsController(IGroupService groupService, IUserService userService)
        {
            this.groupService = groupService;
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult Choose()
        {
            return View();
        }

        //
        // GET: /groups/public

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Public()
        {
            var groups = groupService.GetPublicGroups();
            var viewModel = new List<GroupsListViewModel>();
            bool isTrainer = false;
            foreach (var group in groups)
            {
                if (User.Identity.IsAuthenticated && (
                    group.Trainers.Contains(new UserProfile { UserId = (int)Membership.GetUser().ProviderUserKey }) ||
                    group.TrainerQueries.Contains(new TrainerQuery { UserId = (int)Membership.GetUser().ProviderUserKey, GroupId = group.Id }) ||
                    group.Owner.UserId == (int)Membership.GetUser().ProviderUserKey
                ))
                {
                    isTrainer = true;
                }
                else
                {
                    isTrainer = false;
                }
                viewModel.Add(new GroupsListViewModel
                {
                    Id = group.Id,
                    Name = group.Name,
                    IsTrainer = isTrainer,
                });
            }
            return View("List", viewModel);
        }

        [HttpGet]
        [ActionName("member-of")]
        public ActionResult MemberOf()
        {
            var userId = (int)Membership.GetUser().ProviderUserKey;
            var groups = groupService.GetGroupsMemberOf((int)Membership.GetUser().ProviderUserKey);
            var viewModel = new List<GroupsListViewModel>();
            bool isTrainer = false;
            foreach (var group in groups)
            {
                if (User.Identity.IsAuthenticated && (
                   group.Trainers.Contains(new UserProfile { UserId = (int)Membership.GetUser().ProviderUserKey }) ||
                   group.TrainerQueries.Contains(new TrainerQuery { UserId = (int)Membership.GetUser().ProviderUserKey, GroupId = group.Id }) ||
                   group.Owner.UserId == (int)Membership.GetUser().ProviderUserKey
               ))
                {
                    isTrainer = true;
                }
                else
                {
                    isTrainer = false;
                }
                viewModel.Add(new GroupsListViewModel
                {
                    Id = group.Id,
                    Name = group.Name,
                    IsTrainer = isTrainer,
                });
            }
            return View("List", viewModel);
        }

        [HttpGet]
        [ActionName("not-member-of")]
        public ActionResult NotMemberOf()
        {
            var groups = groupService.GetGroupsNotMemberOf((int)Membership.GetUser().ProviderUserKey);
            var viewModel = new List<GroupsListViewModel>();
            foreach (var group in groups)
            {
                viewModel.Add(new GroupsListViewModel
                {
                    Id = group.Id,
                    Name = group.Name,
                });
            }
            return View("List", viewModel);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Show(int id)
        {
            var group = groupService.GetGroup(id);
            var viewModel = new GroupsShowViewModel
            {
                Id = group.Id,
                Name = group.Name,
            };
            return View(viewModel);
        }

        [AllowAnonymous]
        public ActionResult ShowLessonsMenu(int id)
        {
            var group = groupService.GetGroup(id);
            var viewModel = new GroupsShowMenuViewModel
            {
                Categories = group.Categories as List<Category>,
                Id = group.Id,
                Name = group.Name,
            };
            return PartialView(viewModel);
        }

        public ActionResult ShowTestsMenu(int id)
        {
            var group = groupService.GetGroup(id);
            var viewModel = new GroupsShowMenuViewModel
            {
                Categories = group.Categories as List<Category>,
                Id = group.Id,
                Name = group.Name,
            };
            return PartialView(viewModel);
        }

        [AllowAnonymous]
        public ActionResult EmptyLessonsList(int groupId)
        {
            var viewModel = new List<LessonListViewModel>();
            ViewData["GroupId"] = groupId;
            return View("../Lesson/List", viewModel);
        }

        public ActionResult EmptyTestsList(int groupId)
        {
            var viewModel = new List<TestListViewModel>();
            ViewData["GroupId"] = groupId;
            return View("../Test/List", viewModel);
        }

    }
}
