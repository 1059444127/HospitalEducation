using System.Web.Mvc;

namespace EATMVC.WebApplication.Areas.QuanKeSystem
{
    public class QuanKeSystemAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "QuanKeSystem";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "QuanKeSystem_default",
                "QuanKeSystem/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
