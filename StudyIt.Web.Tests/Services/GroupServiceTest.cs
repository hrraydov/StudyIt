using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using StudyIt.Models;
using StudyIt.Web.Tests.FakeRepositories;
using StudyIt.Service;

namespace StudyIt.Web.Tests.Services
{
    [TestClass]
    public class GroupServiceTest
    {

        private FakeGroupRepository repo;
        private FakeUserRepository userRepo;
        private GroupService groupService;

        public GroupServiceTest()
        {
            List<Group> groups = new List<Group>();
            groups.Add(new Group
            {
                Id = 1,
                Name = "Group1",
                Type = GroupType.Public,
                Owner = new UserProfile
                {
                    UserId = 1,
                    UserName = "hrraydov"
                },
                Trainers = new List<UserProfile> { 
                    new UserProfile{
                        UserId=1,
                        UserName="hrraydov"
                    },
                    new UserProfile{
                        UserId=2,
                        UserName="admin"
                    },
                },
                Members = new List<UserProfile> { 
                    new UserProfile{
                        UserId=3,
                        UserName="User3"
                    },
                    new UserProfile{
                        UserId=4,
                        UserName="User4"
                    },
                },
            });
            groups.Add(new Group
            {
                Id = 2,
                Name = "Group2",
                Type = GroupType.Private,
                Owner = new UserProfile
                {
                    UserId = 2,
                    UserName = "admin"
                },
                Members = new List<UserProfile> { 
                    new UserProfile{
                        UserId=1,
                        UserName="hrraydov"
                    },
                    new UserProfile{
                        UserId=4,
                        UserName="User4"
                    },
                },
            });
            groups.Add(new Group
            {
                Id = 3,
                Name = "Group3",
                Type = GroupType.Private,
                Owner = new UserProfile
                {
                    UserId = 1,
                    UserName = "hrraydov"
                },
                Members = new List<UserProfile> { 
                    new UserProfile{
                        UserId=3,
                        UserName="User3"
                    },
                    new UserProfile{
                        UserId=1,
                        UserName="hrraydov"
                    },
                },
            });
            this.repo = new FakeGroupRepository(groups);
            this.userRepo = new FakeUserRepository(new List<UserProfile>());
            this.groupService = new GroupService(repo, userRepo);
        }

        [TestMethod]
        public void GetByOwnerId()
        {
            int ownerId = 1;

            var result = this.groupService.GetGroupsByOwnerId(ownerId);

            Assert.AreEqual(result[0].Id, 1);
            Assert.AreEqual(result[1].Id, 3);
        }

        [TestMethod]
        public void GetTrainersForGroup()
        {
            var groupId = 1;

            var result = this.groupService.GetTrainersForGroup(groupId);

            Assert.AreEqual(result[0].UserName, "hrraydov");
            Assert.AreEqual(result[1].UserName, "admin");
        }

        [TestMethod]
        public void GetGroupsNotMemberOf()
        {
            var userId = 1;
            var userId2 = 2;

            var result = this.groupService.GetGroupsNotMemberOf(userId);
            var result2 = this.groupService.GetGroupsNotMemberOf(userId2);

            Assert.AreEqual(result.Count, 0);
            Assert.AreEqual(result2.Count, 1);
            Assert.AreEqual(result2[0].Id, 3);
        }
    }
}
