using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CiviKey.Models
{
	public partial class tReleaseNote
	{
        string _version;

        public string Version
        {
            get
            {
                if(_version == null)
                {
                    if( RevisionNumber != 0 )
                        _version = string.Concat( tRoadMap.Name, '.', RevisionNumber );
                    else
                        _version = tRoadMap.Name;
                }
                return _version;
            }
        }
	}
}