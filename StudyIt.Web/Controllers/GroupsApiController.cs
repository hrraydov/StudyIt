using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using StudyIt.Models;
using StudyIt.Data;
using StudyIt.Service;
using StudyIt.Web.ViewModels;

namespace StudyIt.Web.Controllers
{
    public class GroupsApiController : ApiController
    {
        private IGroupService groupService;

        public GroupsApiController()
        {
            this.groupService = new GroupService();
        }

        public GroupsApiController(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        // GET api/Groups/?userId=

        public List<GroupModel> GetGroups(int userId)
        {
            var groups = groupService.GetGroupsByTrainerId(userId);
            var model = new List<GroupModel>();
            foreach (var group in groups)
            {
                model.Add(new GroupModel
                {
                    Id = group.Id,
                    Name = group.Name,
                });
            }
            return model;
        }
    }
}