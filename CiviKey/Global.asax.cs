using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using CK.Web.Mvc.Unity;
using CK.Web.Unity;
using CiviKey.Models;
using CiviKey.Repositories;
using CK.Web.Resources;

namespace CiviKey
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters( GlobalFilterCollection filters )
        {
            filters.Add( new HandleErrorAttribute() );
        }

        public static void RegisterRoutes( RouteCollection routes )
        {
            routes.IgnoreRoute( "{resource}.axd/{*pathInfo}" );

            routes.MapRoute(
                "Contact",
                "contactez-nous",
                new { controller = "Contact", action = "Index" }
                );

            routes.MapRoute(
                "Project",
                "le-projet",
                new { controller = "Project", action = "Index" }
                );

            routes.MapRoute(
                "ProgressSpecific",
                "roadmaps/{version}/{type}",
                new { controller = "Progress", action = "GetSpecificView", type = "classic" }
                );

            routes.MapRoute(
                "Progress",
                "roadmaps",
                new { controller = "Progress", action = "Index" }
                );

            routes.MapRoute(
                "PartnerPage", // Route name
                "partenaires/{safeName}", // URL with parameters
                new { controller = "Partners", action = "GetPartnerPage" } // Parameter defaults
            );

            routes.MapRoute(
               "Partners", // Route name
               "partenaires", // URL with parameters
               new { controller = "Partners", action = "Index" } // Parameter defaults
           );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters( GlobalFilters.Filters );
            RegisterRoutes( RouteTable.Routes );

            UnityContainer c = new UnityContainer();
            c.RegisterType<IControllerActivator, UnityControllerActivator>( new ContainerControlledLifetimeManager() );
            c.RegisterType<CiviKeyEntities>( new UnityPerWebRequestLifetimeManager() );
            c.RegisterType<ContactRepository>( new UnityPerWebRequestLifetimeManager() );
            c.RegisterType<FeatureRepository>( new UnityPerWebRequestLifetimeManager() );
            c.RegisterType<ParticipationRepository>( new UnityPerWebRequestLifetimeManager() );
            c.RegisterType<PartnerRepository>( new UnityPerWebRequestLifetimeManager() );
            DependencyResolver.SetResolver( new UnityDependencyResolver( c ) );
#if RELEASE
            ResourceConfiguration.DebugMode = false;
#endif
        }
    }
}