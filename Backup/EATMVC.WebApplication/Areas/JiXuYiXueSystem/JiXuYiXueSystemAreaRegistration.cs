using System.Web.Mvc;

namespace EATMVC.WebApplication.Areas.JiXuYiXueSystem
{
    public class JiXuYiXueSystemAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "JiXuYiXueSystem";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "JiXuYiXueSystem_default",
                "JiXuYiXueSystem/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
