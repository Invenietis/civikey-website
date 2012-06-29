using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace CiviKey.Models
{
    public static class Helpers
    {
        public static ViewEngineResult GetPartnerSpecificView( ControllerContext ctx, string safeName )
        {
            return ViewEngines.Engines.FindView( ctx, Path.Combine( "Views", safeName ), null );
        }
    }
}