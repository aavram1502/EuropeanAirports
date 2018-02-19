﻿using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EuropeanAirports
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ContainerInitializer.Run();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutomapperConfig.LoadAutomapperProfile();
        }
    }
}
