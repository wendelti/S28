using DotNetNuke.Web.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI
{
    public class RouteMapper : IServiceRouteMapper
    {


        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("WebAPI", "default",
                "{controller}/{action}",new[] { "WebAPI" });
        }
    }
}
