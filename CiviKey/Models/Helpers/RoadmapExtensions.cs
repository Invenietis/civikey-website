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

            return Helpers.CompareVersions( thisVersion, otherVersion, thisIsTrimmed, otherIsTrimmed );
        }

    }
}