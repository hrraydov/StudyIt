using StudyIt.Data;
using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Data
{
    public interface IGroupAdminQueryRepository : IRepository<GroupAdminQuery>
    { }
    public class GroupAdminQueryRepository : Repository<GroupAdminQuery>, IGroupAdminQueryRepository
    {
        public GroupAdminQueryRepository(DbContext context)
            : base(context)
        {

        }
    }
}
