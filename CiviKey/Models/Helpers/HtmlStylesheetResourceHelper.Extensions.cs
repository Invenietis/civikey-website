using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CK.Web.Mvc.Helpers;

namespace CiviKey.Models
{
    public static partial class IHtmlStyleSheetResourceHelperWithConventionExtension
    {
        /// <summary>
        /// A specific ByName convention that searches for .css in the Content/css/ folder
        /// </summary>
        /// <returns>Returns the fluent helper</returns>
        public static IHtmlStyleSheetResourceHelper WithCiviKeyConvention( this IHtmlStyleSheetResourceHelperWithConvention htmlStyleSheetResource )
        {
            return htmlStyleSheetResource.WithConvention( new StyleSheetConventionBasedResourceReferenceStrategy( new string[]
            {
                "~/Content/{0}",
                "~/Content/{0}.css", 
                "~/Content/{0}.less",
                "~/Content/css/{0}",
                "~/Content/css/{0}.css", 
                "~/Content/css/{0}.less"
            }));
        }
    }
}