using System.Web.Mvc;

namespace StudyIt.Web.Areas.GroupAdmin
{
    public class GroupAdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GroupAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "MembersShow",
                "group-admin/members/show/{id}",
                new { controller = "Members", action = "Show" }
            );
            context.MapRoute(
                "TrainerDelete",
                "GroupAdmin/Trainers/Delete/{groupId}/{trainerId}",
                new { controller = "Trainers", action = "Delete" }
            );
            context.MapRoute(
                "MemberDelete",
                "GroupAdmin/Members/Delete/{groupId}/{memberId}",
                new { controller = "Members", action = "Delete" }
            );
            context.MapRoute(
                "CategoryCreate",
                "GroupAdmin/Category/Create/{groupId}",
                new { controller = "Category", action = "Create" }
            );
            context.MapRoute(
                "SubcategoryCreate",
                "GroupAdmin/Subcategory/Create/{categoryId}",
                new { controller = "Subcategory", action = "Create" }
            );
            context.MapRoute(
                "GroupAdmin_default",
                "GroupAdmin/{controller}/{action}/{id}",
                new { controller = "Group", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
