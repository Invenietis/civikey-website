using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;
using BundleTransformer.Core.Bundles;

namespace CivikeyWebsite
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles( BundleCollection bundles )
        {
            #region Scripts
            bundles.Add( new CustomScriptBundle( "~/bundles/jquery" ).Include(
                         "~/Content/scripts/jquery-1.10.2.js" ) );

            bundles.Add( new CustomScriptBundle( "~/bundles/ajax" ).Include(
                         "~/Content/scripts/jquery.unobtrusive-ajax.min.js" ) );

            bundles.Add( new CustomScriptBundle( "~/bundles/scripts/bootstrap" ).Include(
                      "~/Content/scripts/bootstrap.js" ) );

            bundles.Add( new CustomScriptBundle( "~/bundles/scripts/prefix" ).Include(
                      "~/Content/scripts/prefixfree.min.js" ) );

            bundles.Add( new CustomScriptBundle( "~/bundles/scripts/lightbox" ).Include(
                      "~/Content/scripts/lightbox.min.js" ) );

            bundles.Add( new CustomScriptBundle( "~/bundles/scripts/angular" ).Include(
                      "~/Content/scripts/angular.js" ) );

            bundles.Add( new CustomScriptBundle( "~/bundles/scripts/upload" )
                .Include( "~/Content/scripts/angular-file-upload-shim.js")
                .Include( "~/Content/scripts/angular-file-upload.js" )
                .Include( "~/Content/scripts/app/app.js")
                .Include( "~/Content/scripts/app/controllers/KeyboardsController.js" ) );

            #endregion

            #region Styles

            bundles.Add( new CustomScriptBundle( "~/bundles/scripts/localScroll" ).Include(
                     "~/Content/scripts/jquery.scrollTo-1.4.3.1-min.js", "~/Content/scripts/jquery.localscroll-1.2.7-min.js" ) );

            bundles.Add( new CustomStyleBundle( "~/bundles/styles/bootstrap" ).Include(
                      "~/Content/styles/bootstrap/bootstrap.less" ) );

            bundles.Add( new CustomStyleBundle( "~/bundles/styles/lightbox" ).Include(
                      "~/Content/styles/lightbox.css" ) );

            bundles.Add( new CustomStyleBundle( "~/bundles/styles/site" ).Include(
                     "~/Content/styles/hover-effects.css", "~/Content/styles/site.less" ) );
            #endregion
        }
    }
}
