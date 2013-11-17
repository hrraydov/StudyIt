using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Data
{
    public interface ITestResultRepository : IRepository<TestResult> { }
    public class TestResultRepository : Repository<TestResult>, ITestResultRepository
    {
        public TestResultRepository(DbContext context)
            : base(context)
        {
        }
    }
}
