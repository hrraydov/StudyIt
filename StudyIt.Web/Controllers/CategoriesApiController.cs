using StudyIt.Service;
using StudyIt.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudyIt.Web.Controllers
{
    public class CategoriesApiController : ApiController
    {
        private ICategoryService categoryService;

        public CategoriesApiController()
        {
            this.categoryService = new CategoryService();
        }

        public CategoriesApiController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public List<CategoryModel> GetCategories(int groupId)
        {
            var categories = categoryService.GetCategoriesByGroupId(groupId);
            var model = new List<CategoryModel>();
            foreach (var category in categories)
            {
                model.Add(new CategoryModel
                {
                    Id = category.Id,
                    Name = category.Name,
                });
            }
            return model;
        }
    }
}
