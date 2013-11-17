using StudyIt.Data;
using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Service
{
    public interface ICommentService
    {
        void CreateComment(Comment comment);
    }
    public class CommentService : ICommentService
    {
        private ICommentRepository commentRepo;

        public CommentService()
        {
            this.commentRepo = new CommentRepository(new StudyItContext());
        }

        public CommentService(ICommentRepository commentRepo)
        {
            this.commentRepo = commentRepo;
        }
        /// <summary>
        /// Creates comment
        /// </summary>
        /// <param name="comment">The comment to be created</param>
        public void CreateComment(Comment comment)
        {
            this.commentRepo.Add(comment);
            this.commentRepo.Save();
        }
    }
}
