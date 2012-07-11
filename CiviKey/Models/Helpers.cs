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


        public static Version GetVersionFromRoadmapName( string name)
        {
            bool isTrimmed;
            return GetVersionFromRoadmapName( name, out isTrimmed );
        }

        public static Version GetVersionFromRoadmapName( string name, out bool isTrimmed )
        {
            Version version;
            isTrimmed = false;
            if( !Version.TryParse( name, out version ) )
            {
                //if the name is not a version, it may be of the form 2.5.X
                if( !Version.TryParse( name.Substring( 0, name.LastIndexOf( '.' ) ), out version ) )
                {
                    return null;
                }
                isTrimmed = true;
            }
            return version;
        }
    }
}