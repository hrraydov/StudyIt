using System.Web.Mvc;

namespace StudyIt.Web.Areas.Trainer
{
    public class TrainerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Trainer";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Trainer_default",
                "Trainer/{controller}/{action}/{id}",
                new { controller="Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
