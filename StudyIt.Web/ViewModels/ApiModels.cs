using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyIt.Web.ViewModels
{
    public class GroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SubcategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}