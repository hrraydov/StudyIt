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
    public class SubcategoriesApiController : ApiController
    {
        private ISubcategoryService subcategoryService;

        public SubcategoriesApiController()
        {
            this.subcategoryService = new SubcategoryService();
        }

        public SubcategoriesApiController(ISubcategoryService subcategoryService)
        {
            this.subcategoryService = subcategoryService;
        }

        public List<SubcategoryModel> GetSubcategories(int categoryId)
        {
            var subcategories = subcategoryService.GetSubcategoriesByCategoryId(categoryId);
            var model = new List<SubcategoryModel>();
            foreach (var subcategory in subcategories)
            {
                model.Add(new SubcategoryModel
                {
                    Id = subcategory.Id,
                    Name = subcategory.Name,
                });
            }
            return model;
        }
    }
}
