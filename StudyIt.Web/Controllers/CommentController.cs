using StudyIt.Models;
using StudyIt.Service;
using StudyIt.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudyIt.Web.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {

        private ICommentService commentService;

        public CommentController()
        {
            this.commentService = new CommentService();
        }

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        //
        // GET: /Comment/

        [HttpPost]
        public ActionResult Create(CommentCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var comment = new Comment
                {
                    AuthorId = (int)Membership.GetUser().ProviderUserKey,
                    CreationDate = DateTime.Now,
                    Desc = viewModel.Desc,
                    LessonId = viewModel.LessonId,
                };
                commentService.CreateComment(comment);
                return Redirect("/lesson/show/" + viewModel.LessonId);
            }

            return Redirect("/lesson/show/" + viewModel.LessonId);
        }

    }
}
