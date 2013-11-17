using StudyIt.Data;
using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Service
{
    public interface IGroupQueryService
    {
        GroupQuery GetQuery(int queryId);
        void DeleteQuery(int queryId);
        void CreateQuery(GroupQuery query);
    }
    public class GroupQueryService : IGroupQueryService
    {
        private IGroupQueryRepository queryRepo;

        public GroupQueryService()
        {
            this.queryRepo = new GroupQueryRepository(new StudyItContext());
        }

        public GroupQueryService(IGroupQueryRepository queryRepo)
        {
            this.queryRepo = queryRepo;
        }

        /// <summary>
        /// Gets given query for member
        /// </summary>
        /// <param name="queryId">The id of a query for member</param>
        /// <returns></returns>
        public GroupQuery GetQuery(int queryId)
        {
            return queryRepo.Get(queryId);
        }

        /// <summary>
        /// Deletes given query for member
        /// </summary>
        /// <param name="queryId">The id of a query for member</param>
        public void DeleteQuery(int queryId)
        {
            queryRepo.Delete(queryId);
            queryRepo.Save();
        }

        /// <summary>
        /// Creates query for member
        /// </summary>
        /// <param name="query">The query to be created</param>
        public void CreateQuery(GroupQuery query)
        {
            queryRepo.Add(query);
            queryRepo.Save();
        }
    }
}
