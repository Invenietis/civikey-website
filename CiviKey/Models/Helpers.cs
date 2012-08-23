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


        public static Version GetVersionFromRoadmapName( string name )
        {
            bool isTrimmed;
            return GetVersionFromRoadmapName( name, out isTrimmed );
        }

        public static Version GetVersionFromRoadmapName( string name, out bool isTrimmed )
        {
            Version version = null;
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

        /// <summary>
        /// This methods gets a fileName following this pattern : x-x-versionNumber.exe
        /// and retrives a version object from it.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static Version GetVersionFromFileName( string fileName )
        {
            if( String.IsNullOrWhiteSpace( fileName ) ) return null;

            string versionString = fileName.Substring( fileName.LastIndexOf( '-' ) + 1 );
            versionString = Path.GetFileNameWithoutExtension( versionString );
            Version version = null;
            Version.TryParse( versionString, out version );

            return version;
        }

        /// <summary>
        /// Compares two versions, handling versions like "2.5.X" (considered greater than any 2.5.*)
        /// </summary>
        /// <param name="thisVersion">A version object</param>
        /// <param name="otherVersion">The Version object with which to compare the first one</param>
        /// <returns>1 if thisVersion is stronger. -1 if thisVersion is weaker, 0 if they are equal</returns>
        public static int CompareVersions( Version thisVersion, Version otherVersion )
        {
            bool thisIsTrimmed = thisVersion.ToString().Contains( "X" );
            bool otherIsTrimmed = otherVersion.ToString().Contains( "X" );
            return CompareVersions( thisVersion, otherVersion, thisIsTrimmed, otherIsTrimmed );
        }

        internal static int CompareVersions( Version thisVersion, Version otherVersion, bool thisIsTrimmed, bool otherIsTrimmed )
        {
            if( thisVersion != null && otherVersion != null )
            {
                if( !thisIsTrimmed && !otherIsTrimmed ) //if none are trimmed, these are classic versions name, use the built-in version comparison.
                    return thisVersion.CompareTo( otherVersion );
                else
                {
                    if( thisVersion.Major != otherVersion.Major
                        || thisVersion.Minor != otherVersion.Minor ) //if the two versions have different Major & Minor, the .X won't change anything to the compareto method result. We just trim the "X" and compare as classic Versions.
                    {
                        return thisVersion.CompareTo( otherVersion );
                    }
                    else
                    {
                        if( thisIsTrimmed )
                        {
                            if( otherIsTrimmed ) return 0; //if the two are trimmed, they are equals
                            return 1; //if only "this" is trimmed, "this" is stronger.
                        }
                        return -1; //if only "other" is trimmed, "this" is weaker.
                    }
                }
            }
            else
            {
                if( thisVersion == null ) return -1; //if thisVersion is null, the other is considered greater (even if the other other null as well.
                return 1;
            }
        }
    }
}