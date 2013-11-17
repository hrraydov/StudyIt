using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyIt.Web.ViewModels
{
    public class AdminGroupAdminsShowViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class AdminGroupAdminsQueriesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}