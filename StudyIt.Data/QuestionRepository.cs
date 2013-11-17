using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Data
{
    public interface IQuestionRepository : IRepository<Question> { }
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(DbContext context)
            : base(context)
        {
        }
    }
}
