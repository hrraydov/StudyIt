using StudyIt.Data;
using StudyIt.Data;
using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Service
{
    public interface IGroupAdminQueryService
    {
        void CreateQuery(GroupAdminQuery query);
        List<GroupAdminQuery> GetQueries();
        GroupAdminQuery GetQuery(int queryId);
        void DeleteQuery(int queryId);
    }
    public class GroupAdminQueryService : IGroupAdminQueryService
    {
        private IGroupAdminQueryRepository queryRepo;

        public GroupAdminQueryService()
        {
            this.queryRepo = new GroupAdminQueryRepository(new StudyItContext());
        }

        public GroupAdminQueryService(IGroupAdminQueryRepository queryRepo)
        {
            this.queryRepo = queryRepo;
        }
        /// <summary>
        /// Creates query for group admin
        /// </summary>
        /// <param name="query">The query to be created</param>
        public void CreateQuery(GroupAdminQuery query)
        {
            this.queryRepo.Add(query);
            this.queryRepo.Save();
        }

        /// <summary>
        /// Gets all queries for group admin
        /// </summary>
        /// <returns></returns>
        public List<GroupAdminQuery> GetQueries()
        {
            return this.queryRepo.GetAll().ToList();
        }

        /// <summary>
        /// Gets given query for group admin
        /// </summary>
        /// <param name="queryId">The id of a query for group admin</param>
        /// <returns></returns>
        public GroupAdminQuery GetQuery(int queryId)
        {
            return this.queryRepo.Get(queryId);
        }

        /// <summary>
        /// Deletes given query for group admin
        /// </summary>
        /// <param name="queryId">The id of a query for group admin</param>
        public void DeleteQuery(int queryId)
        {
            this.queryRepo.Delete(queryId);
            this.queryRepo.Save();
        }
    }
}
