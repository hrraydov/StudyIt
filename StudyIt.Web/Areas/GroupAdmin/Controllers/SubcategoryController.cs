using StudyIt.Models;
using StudyIt.Service;
using StudyIt.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudyIt.Web.Areas.GroupAdmin.Controllers
{
    [Authorize(Roles = "GroupAdmin")]
    public class SubcategoryController : Controller
    {
        private ICategoryService categoryService;
        private ISubcategoryService subcategoryService;

        public SubcategoryController()
        {
            this.categoryService = new CategoryService();
            this.subcategoryService = new SubcategoryService();
        }

        public SubcategoryController(ICategoryService categoryService, ISubcategoryService subcategoryService)
        {
            this.categoryService = categoryService;
            this.subcategoryService = subcategoryService;
        }

        //
        // GET: /GroupAdmin/Subcategory/Create

        [HttpGet]
        public ActionResult Create(int categoryId)
        {
            var viewModel = new GroupAdminSubcategoryCreateViewModel
            {
                CategoryId = categoryId,
                CategoryName = categoryService.GetCategoryName(categoryId),
                GroupName = categoryService.GetCategoryGroupName(categoryId),
            };
            return View(viewModel);
        }

        //
        // POST: /GroupAdmin/Subcategory/Create

        [HttpPost]
        public ActionResult Create(GroupAdminSubcategoryCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var subcategory = new Subcategory
                {
                    Name = viewModel.Name,
                    CategoryId = viewModel.CategoryId,
                };
                subcategoryService.CreateSubcategory(subcategory);
                return Redirect("/GroupAdmin/Group");
            }
            return View(viewModel);
        }

        //
        // GET: /GroupAdmin/Subcategory/Delete/5

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var subcategory = subcategoryService.GetSubcategory(id);
            var viewModel = new GroupAdminSubcategoryDeleteViewModel
            {
                CategoryName = subcategory.Category.Name,
                GroupName = subcategory.Category.Group.Name,
                Name = subcategory.Name,
            };
            return View(viewModel);
        }

        //
        // POST: /GroupAdmin/Subcategory/Delete/5

        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            subcategoryService.DeleteSubcategory(id);
            return Redirect("/GroupAdmin/Group");
        }
    }
}
