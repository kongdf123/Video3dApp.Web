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
				url: "Video3d/VRVideo.mp4",
				defaults: new { controller = "Video3d", action = "ReadVideo"}
			);

			routes.MapRoute(
				name: "Brand_USA",
				url: "Video3d/BrandUSA.html",
				defaults: new { controller = "Video3d", action = "BrandUSA" }
			);
			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}",
				defaults: new { controller = "Video3d", action = "BrandUSA" }
			);
		}
	}
}