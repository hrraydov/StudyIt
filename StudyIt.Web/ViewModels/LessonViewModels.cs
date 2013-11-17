using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyIt.Web.ViewModels
{
    public class LessonListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortContent { get; set; }
        public DateTime CreationDate { get; set; }
        public string AuthorName { get; set; }
        public int CommentsCount { get; set; }
        public int GroupId { get; set; }
    }

    public class LessonShowViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public string AuthorName { get; set; }
        public List<Comment> Comments { get; set; }
    }
}