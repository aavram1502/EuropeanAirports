using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using EuropeanAirports.Controllers;
using Managers;
using Services;

namespace EuropeanAirports
{
    public class ContainerInitializer
    {
        public static void Run()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<AirportManager>().As<IAirportManager>().SingleInstance();

            builder.RegisterType<HttpRequestService>().As<IHttpRequestService>().SingleInstance();
            builder.RegisterType<PeriodicalService>().As<IPeriodicalService>().SingleInstance();
            builder.RegisterType<AirportService>().As<IAirportService>().SingleInstance();
            builder.RegisterType<DistanceService>().As<IDistanceService>().SingleInstance();

            var controllerAssembly = Assembly.GetAssembly(typeof(HomeController));
            builder.RegisterControllers(controllerAssembly);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}