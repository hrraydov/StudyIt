using StudyIt.Data;
using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Web.Tests.FakeRepositories
{
    public class FakeUserRepository : IUserRepository
    {
        private List<UserProfile> getList;
        private List<UserProfile> setList;

        public FakeUserRepository(List<UserProfile> getList)
        {
            this.getList = getList;
            this.setList = getList;
        }

        public void Add(UserProfile item)
        {
            this.setList.Add(item);
        }

        public UserProfile Get(int id)
        {
            return this.getList.Where(x => x.UserId == id).First();
        }

        public IQueryable<UserProfile> GetAll()
        {
            return this.getList.AsQueryable();
        }

        public void Update(UserProfile item)
        {
            var temp = this.setList.Where(x => x.UserId == item.UserId).First();
            this.setList.Remove(temp);
            this.setList.Add(item);
        }

        public void Delete(UserProfile item)
        {
            this.setList.Remove(item);
        }

        public void Delete(int id)
        {
            var temp = this.setList.Where(x => x.UserId == id).First();
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
