using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Data
{
    public interface IGroupQueryRepository : IRepository<GroupQuery> { }
    public class GroupQueryRepository : Repository<GroupQuery>, IGroupQueryRepository
    {
        public GroupQueryRepository(DbContext context)
            : base(context)
        {
        }
    }
}
