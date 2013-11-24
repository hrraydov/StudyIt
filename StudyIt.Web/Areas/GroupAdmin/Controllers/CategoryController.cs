using StudyIt.Models;
using StudyIt.Service;
using StudyIt.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyIt.Web.Areas.GroupAdmin.Controllers
{
    [Authorize(Roles="GroupAdmin,Admin")]
    public class CategoryController : Controller
    {
        private ICategoryService categoryService;
        private IGroupService groupService;

        public CategoryController()
        {
            this.categoryService = new CategoryService();
            this.groupService = new GroupService();
        }

        public CategoryController(ICategoryService categoryService, IGroupService groupService)
        {
            this.categoryService = categoryService;
            this.groupService = groupService;
        }

        //
        //GET: /GroupAdmin/Category/Create

        [HttpGet]
        public ActionResult Create(int groupId)
        {
            var viewModel = new GroupAdminCategoryCreateViewModel
            {
                GroupId = groupId,
                GroupName = groupService.GetGroupName(groupId),
            };
            return View(viewModel);
        }

        //
        //POST: /GroupAdmin/Category/Create

        [HttpPost]
        public ActionResult Create(GroupAdminCategoryCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = viewModel.Name,
                    GroupId = viewModel.GroupId,
                };
                categoryService.CreateCategory(category);
                return Redirect("/GroupAdmin/Group");
            }
            return View(viewModel);
        }

        //
        // GET: /GroupAdmin/Category/Delete/5

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var category = categoryService.GetCategory(id);
            var viewModel = new GroupAdminCategoryDeleteViewModel
            {
                Name = category.Name,
                GroupName = category.Group.Name,
            };
            return View(viewModel);
        }

        //
        // POST: /GroupAdmin/Category/Delete/5

        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            categoryService.DeleteCategory(id);
            return Redirect("/GroupAdmin/Group");
        }
    }
}
