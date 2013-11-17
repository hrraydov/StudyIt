using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyIt.Web.ViewModels
{
    public class GroupAdminMembersShowViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
    }

    public class GroupAdminMembersQueriesViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
    }
}