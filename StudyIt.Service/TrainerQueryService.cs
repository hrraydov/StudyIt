using StudyIt.Data;
using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Service
{
    public interface ITrainerQueryService
    {
        TrainerQuery GetQuery(int queryId);
        void DeleteQuery(int queryId);
        void CreateQuery(TrainerQuery query);
    }
    public class TrainerQueryService : ITrainerQueryService
    {
        private ITrainerQueryRepository queryRepo;

        public TrainerQueryService()
        {
            this.queryRepo = new TrainerQueryRepository(new StudyItContext());
        }

        public TrainerQueryService(ITrainerQueryRepository queryRepo)
        {
            this.queryRepo = queryRepo;
        }

        /// <summary>
        /// Gets query for trainer by given id
        /// </summary>
        /// <param name="queryId">The id of a query</param>
        /// <returns></returns>
        public TrainerQuery GetQuery(int queryId)
        {
            return queryRepo.Get(queryId);
        }

        /// <summary>
        /// Deletes query for trainer
        /// </summary>
        /// <param name="queryId">The id of the query to be deleted</param>
        public void DeleteQuery(int queryId)
        {
            queryRepo.Delete(queryId);
            queryRepo.Save();
        }

        /// <summary>
        /// Creates query for trainer
        /// </summary>
        /// <param name="query">The query to be created</param>
        public void CreateQuery(TrainerQuery query)
        {
            queryRepo.Add(query);
            queryRepo.Save();
        }
    }
}
