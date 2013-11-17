using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyIt.Web.Tests.FakeRepositories;
using StudyIt.Models;
using System.Collections.Generic;
using StudyIt.Service;
using StudyIt.Data;
using StudyIt.Web.Controllers;
using System.Web.Mvc;
using StudyIt.Web.ViewModels;

namespace StudyIt.Web.Tests.Controllers
{
    [TestClass]
    public class GroupsControllerTest
    {
        
        [TestMethod]
        public void Show()
        {
            List<Group> groups = new List<Group>();
            groups.Add(new Group
            {
                Id = 1,
                Name = "Group1",
                Type = GroupType.Public,
            });
            FakeGroupRepository repo = new FakeGroupRepository(groups);
            FakeUserRepository userRepo = new FakeUserRepository(new List<UserProfile>());
            GroupService groupService = new GroupService(repo, userRepo);
            GroupsController controller = new GroupsController(groupService, new UserService());
            ViewResult res = controller.Show(1) as ViewResult;
            GroupsShowViewModel viewModel = (GroupsShowViewModel)res.Model;
            var expected = new GroupsShowViewModel { Id = 1, Name = "Group1" };
            Assert.AreEqual(viewModel.Id, expected.Id);
        }
    }
}
