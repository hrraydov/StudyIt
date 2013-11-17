using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Data
{
    public interface ILessonRepository : IRepository<Lesson> { }
    public class LessonRepository : Repository<Lesson>, ILessonRepository
    {
        public LessonRepository(DbContext context)
            : base(context)
        {
        }

        public void Update(Lesson lesson)
        {
            var oldLesson = base.set.Find(lesson.Id);
            lesson.SubcategoryId = oldLesson.SubcategoryId;
            lesson.AuthorId = oldLesson.AuthorId;
            base.context.Entry(oldLesson).CurrentValues.SetValues(lesson);
        }

        public void Delete(int lessonId)
        {
            var lesson = this.Get(lessonId);
            var comments = lesson.Comments.ToList();

            foreach (var item in comments)
            {
                context.Set<Comment>().Remove(item);
            }


            context.Set<Lesson>().Remove(lesson);
        }
    }
}
