using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CK.Core;
using CK.Monitoring;
using CK.Web;

namespace CivikeyWebsite
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters( GlobalFilters.Filters );
            RouteConfig.RegisterRoutes( RouteTable.Routes );
            BundleConfig.RegisterBundles( BundleTable.Bundles );


            SystemActivityMonitor.RootLogPath = AppSettings.Default.GetRequired<string>( "LogFolderPath" ); //"~/Private/Logs" 
            GrandOutput.EnsureActiveDefaultWithDefaultSettings();

        }
    }
}
