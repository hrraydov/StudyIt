using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyIt.Web.ViewModels
{
    public class GroupAdminTrainersShowViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
    }

    public class GroupAdminTrainersQueriesViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
    }
}