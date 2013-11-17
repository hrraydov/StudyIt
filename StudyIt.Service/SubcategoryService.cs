using StudyIt.Data;
using StudyIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyIt.Service
{
    public interface ISubcategoryService
    {
        void CreateSubcategory(Subcategory subcategory);
        void DeleteSubcategory(int subcategoryId);
        Subcategory GetSubcategory(int subcategoryId);
        List<Subcategory> GetSubcategoriesByCategoryId(int categoryId);
        Group GerGroupOfSubcategory(int subcategoryId);
    }

    public class SubcategoryService : ISubcategoryService
    {
        private ISubcategoryRepository subcategoryRepo;

        public SubcategoryService()
        {
            this.subcategoryRepo = new SubcategoryRepository(new StudyItContext());
        }

        public SubcategoryService(ISubcategoryRepository categoryRepo)
        {
            this.subcategoryRepo = categoryRepo;
        }

        /// <summary>
        /// Creates subcategory
        /// </summary>
        /// <param name="subcategory">The subcategory to be created</param>
        public void CreateSubcategory(Subcategory subcategory)
        {
            subcategoryRepo.Add(subcategory);
            subcategoryRepo.Save();
        }

        /// <summary>
        /// Deletes subcategory by given id
        /// </summary>
        /// <param name="subcategoryId">The id of the subcategory to be deleted</param>
        public void DeleteSubcategory(int subcategoryId)
        {
            subcategoryRepo.Delete(subcategoryId);
            subcategoryRepo.Save();
        }

        /// <summary>
        /// Gets subcategory by given id
        /// </summary>
        /// <param name="subcategoryId">The id of a subcategory</param>
        /// <returns></returns>
        public Subcategory GetSubcategory(int subcategoryId)
        {
            return subcategoryRepo.Get(subcategoryId);
        }

        /// <summary>
        /// Gets all subcategories of given category
        /// </summary>
        /// <param name="categoryId">The id of a category</param>
        /// <returns></returns>
        public List<Subcategory> GetSubcategoriesByCategoryId(int categoryId)
        {
            return subcategoryRepo.GetAll().Where(x => x.Category.Id == categoryId).ToList();
        }

        /// <summary>
        /// Gets group of given subcategory
        /// </summary>
        /// <param name="subcategoryId">The id of a subcategory</param>
        /// <returns></returns>
        public Group GerGroupOfSubcategory(int subcategoryId)
        {
            var subcategory = this.GetSubcategory(subcategoryId);
            return subcategory.Category.Group;
        }
    }
}
