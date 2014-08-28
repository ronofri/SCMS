using System.Web.Mvc;

namespace SCMS.Areas.GM
{
    public class GMAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GM";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GM_default",
                "{controller}/{action}/{id}",
                new { controller = "Inbox", action = "Index", id = UrlParameter.Optional },
                new { controller = "Inbox" }
            );
        }
    }
}
