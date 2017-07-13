using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Video3dApp.Web
{
	public class MvcApplication : HttpApplication
	{
		protected void Application_Start() {
			RegisterRoutes(RouteTable.Routes);
		}

		public static void RegisterRoutes(RouteCollection routes) {
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Video3d",
				url: "Video3d/{action}.mp4",
				defaults: new { controller = "Video3d", action = "ReadVideo", id = UrlParameter.Optional }
			);
			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Video3d", action = "Detail", id = UrlParameter.Optional }
			);
		}
	}
}