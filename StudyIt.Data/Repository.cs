using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Data
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        T Get(int id);
        IQueryable<T> GetAll();
        void Update(T item);
        void Delete(T item);
        void Delete(int id);
        void Save();
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext context;
        protected DbSet<T> set;

        public Repository(DbContext context)
        {
            this.context = context;
            this.set = this.context.Set<T>();
        }

        public void Add(T item)
        {
            this.set.Add(item);
        }

        public T Get(int id)
        {
            return this.set.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return this.set;
        }

        public void Update(T item)
        {
            this.context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(T item)
        {
            this.set.Remove(item);
        }

        public void Delete(int id)
        {
            var item = this.Get(id);
            this.Delete(item);
        }


        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
