using System.Web.Mvc;

namespace EATMVC.WebApplication.Areas.JinXiuSystem
{
    public class JinXiuSystemAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "JinXiuSystem";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "JinXiuSystem_default",
                "JinXiuSystem/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
