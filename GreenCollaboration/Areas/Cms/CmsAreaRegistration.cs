using System.Web.Mvc;

namespace GreenCollaboration.Areas.Cms
{
    public class CmsAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Cms";

        public override void RegisterArea(AreaRegistrationContext context)  // formateret i Reshaper
        {
            //Routning kan se sådan ud
            context.MapRoute(
                "Cms_css",
                "Cms/{controller}/{action}/{cssName}",
                new { action = "Index", cssName = UrlParameter.Optional }
            );
            context.MapRoute(
              "Cms_default",
              "Cms/{controller}/{action}/{templateName}",
              new { action = "Index", templateName = UrlParameter.Optional }
          );
        }
    }
}