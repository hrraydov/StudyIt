using StudyIt.Data;
using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Web.Tests.FakeRepositories
{
    public class FakeGroupRepository : IGroupRepository
    {
        private List<Group> getList;
        private List<Group> setList;

        public FakeGroupRepository(List<Group> getList)
        {
            this.getList = getList;
            this.setList = getList;
        }

        public void Add(Group item)
        {
            this.setList.Add(item);
        }

        public Group Get(int id)
        {
            return this.getList.Where(x => x.Id == id).First();
        }

        public IQueryable<Group> GetAll()
        {
            return this.getList.AsQueryable();
        }

        public void Update(Group item)
        {
            var temp = this.setList.Where(x => x.Id == item.Id).First();
            this.setList.Remove(temp);
            this.setList.Add(item);
        }

        public void Delete(Group item)
        {
            this.setList.Remove(item);
        }

        public void Delete(int id)
        {
            var temp = this.setList.Where(x => x.Id == id).First();
            this.setList.Remove(temp);
        }

        public void Save()
        {
            this.getList.Clear();
            foreach (var elem in setList)
            {
                this.getList.Add(elem);
            }
        }
    }
}
