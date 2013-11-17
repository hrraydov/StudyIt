using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Data
{
    public interface ITrainerQueryRepository : IRepository<TrainerQuery>
    {
    }
    public class TrainerQueryRepository : Repository<TrainerQuery>, ITrainerQueryRepository
    {
        public TrainerQueryRepository(DbContext context)
            : base(context)
        {

        }
    }
}
