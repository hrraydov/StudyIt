using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Data
{
    public interface IUserRepository : IRepository<UserProfile>
    {

    }
    public class UserRepository : Repository<UserProfile>, IUserRepository
    {
        public UserRepository(DbContext context)
            : base(context)
        {
        }
    }
}
