using StudyIt.Data;
using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Web.Tests.FakeRepositories
{
    public class FakeLessonRepository : ILessonRepository
    {
        private List<Lesson> getList;
        private List<Lesson> setList;

        public FakeLessonRepository(List<Lesson> getList)
        {
            this.getList = getList;
            this.setList = getList;
        }

        public void Add(Lesson item)
        {
            this.setList.Add(item);
        }

        public Lesson Get(int id)
        {
            return this.getList.Where(x => x.Id == id).First();
        }

        public IQueryable<Lesson> GetAll()
        {
            return this.getList.AsQueryable();
        }

        public void Update(Lesson item)
        {
            var temp = this.setList.Where(x => x.Id == item.Id).First();
            this.setList.Remove(temp);
            this.setList.Add(item);
        }

        public void Delete(Lesson item)
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
