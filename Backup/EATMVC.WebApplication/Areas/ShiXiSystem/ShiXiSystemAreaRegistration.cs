using System.Web.Mvc;

namespace EATMVC.WebApplication.Areas.ShiXiSystem
{
    public class ShiXiSystemAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ShiXiSystem";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ShiXiSystem_default",
                "ShiXiSystem/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
