using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CiviKey.Models
{
    public partial class tRoadMap : IComparable<tRoadMap>
    {
        public int CompareTo( tRoadMap other )
        {
            Version thisVersion;
            Version otherVersion;
            bool thisIsTrimmed = false;
            bool otherIsTrimmed = false;

            thisVersion = Helpers.GetVersionFromRoadmapName( Name, out thisIsTrimmed );
            otherVersion = Helpers.GetVersionFromRoadmapName( other.Name, out otherIsTrimmed );

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