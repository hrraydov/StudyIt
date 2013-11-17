using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyIt.Web.ViewModels
{
    public class GroupsListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsTrainer { get; set; }
    }

    public class GroupsShowViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GroupsShowMenuViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Category> Categories { get; set; }
    }
}