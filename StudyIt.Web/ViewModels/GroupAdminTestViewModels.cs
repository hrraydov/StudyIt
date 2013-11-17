using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyIt.Web.ViewModels
{
    public class GroupAdminTestDetailsViewModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public List<Question> Questions { get; set; }
        public string SubcategoryName { get; set; }
        public string CategoryName { get; set; }
        public string GroupName { get; set; }
    }

    public class GroupAdminTestDeleteViewModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string SubcategoryName { get; set; }
        public string CategoryName { get; set; }
        public string GroupName { get; set; }
    }
}