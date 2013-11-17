using StudyIt.Data;
using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Service
{
    public interface ILessonService
    {
        Lesson GetLesson(int lessonId);
        void CreateLesson(Lesson lesson);
        void DeleteLesson(int lessonId);
        List<Lesson> GetLessonsByAuthorId(int authorId);
        void EditLesson(Lesson lesson);
        List<Lesson> GetLessonsBySubcategoryId(int subcategoryId);
    }
    public class LessonService : ILessonService
    {
        private ILessonRepository lessonRepo;

        public LessonService()
        {
            this.lessonRepo = new LessonRepository(new StudyItContext());
        }

        public LessonService(ILessonRepository lessonRepo)
        {
            this.lessonRepo = lessonRepo;
        }

        /// <summary>
        /// Get lesson by given id
        /// </summary>
        /// <param name="lessonId">The id of a lesson</param>
        /// <returns></returns>
        public Lesson GetLesson(int lessonId)
        {
            return lessonRepo.Get(lessonId);
        }

        /// <summary>
        /// Creates lesson
        /// </summary>
        /// <param name="lesson">The lesson to be created</param>
        public void CreateLesson(Lesson lesson)
        {
            lessonRepo.Add(lesson);
            lessonRepo.Save();
        }

        /// <summary>
        /// Deletes given lesson
        /// </summary>
        /// <param name="lessonId">The id of the lesson to be deleted</param>
        public void DeleteLesson(int lessonId)
        {
            lessonRepo.Delete(lessonId);
            lessonRepo.Save();
        }

        /// <summary>
        /// Gets all lessons by given id of author
        /// </summary>
        /// <param name="authorId">The id of the author</param>
        /// <returns></returns>
        public List<Lesson> GetLessonsByAuthorId(int authorId)
        {
            return lessonRepo.GetAll().Where(x => x.Author.UserId == authorId).ToList();
        }

        /// <summary>
        /// Edits lesson
        /// </summary>
        /// <param name="lesson">The lesson to be edited</param>
        public void EditLesson(Lesson lesson)
        {
            lessonRepo.Update(lesson);
            lessonRepo.Save();
        }

        /// <summary>
        /// Gets all lessons by given id of subcategory
        /// </summary>
        /// <param name="subcategoryId">The id of a subcategory</param>
        /// <returns></returns>
        public List<Lesson> GetLessonsBySubcategoryId(int subcategoryId)
        {
            return lessonRepo.GetAll().Where(x => x.Subcategory.Id == subcategoryId).ToList();
        }
    }
}
