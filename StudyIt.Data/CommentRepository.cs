using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Data
{
    public interface ICommentRepository : IRepository<Comment> { }
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext context)
            : base(context)
        {
        }
    }
}
