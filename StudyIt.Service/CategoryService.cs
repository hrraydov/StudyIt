using StudyIt.Data;
using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Service
{
    public interface ICategoryService
    {
        List<Category> GetCategoriesByGroupId(int groupId);
        void CreateCategory(Category category);
        Category GetCategory(int categoryId);
        void DeleteCategory(int categoryId);
        string GetCategoryName(int categoryId);
        string GetCategoryGroupName(int categoryId);
    }
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository categoryRepo;

        public CategoryService()
        {
            this.categoryRepo = new CategoryRepository(new StudyItContext());
        }

        public CategoryService(ICategoryRepository categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        /// <summary>
        /// Gets all categories for given group
        /// </summary>
        /// <param name="groupId">The id of a group</param>
        /// <returns></returns>
        public List<Category> GetCategoriesByGroupId(int groupId)
        {
            return categoryRepo.GetAll().Where(x => x.Group.Id == groupId).ToList();
        }

        /// <summary>
        /// Creates a category
        /// </summary>
        /// <param name="category">The category to be created</param>
        public void CreateCategory(Category category)
        {
            categoryRepo.Add(category);
            categoryRepo.Save();
        }

        /// <summary>
        /// Gets a category by given id
        /// </summary>
        /// <param name="categoryId">The id of a category</param>
        /// <returns></returns>
        public Category GetCategory(int categoryId)
        {
            return categoryRepo.Get(categoryId);
        }

        /// <summary>
        /// Deletes category by given id
        /// </summary>
        /// <param name="categoryId">The id of a category</param>
        public void DeleteCategory(int categoryId)
        {
            categoryRepo.Delete(categoryId);
            categoryRepo.Save();
        }

        /// <summary>
        /// Gets the name of given category
        /// </summary>
        /// <param name="categoryId">The id of a category</param>
        /// <returns></returns>
        public string GetCategoryName(int categoryId)
        {
            return categoryRepo.Get(categoryId).Name;
        }

        /// <summary>
        /// Gets the name of the group of given category
        /// </summary>
        /// <param name="categoryId">The id of a category</param>
        /// <returns></returns>
        public string GetCategoryGroupName(int categoryId)
        {
            return categoryRepo.Get(categoryId).Group.Name;
        }
    }
}
