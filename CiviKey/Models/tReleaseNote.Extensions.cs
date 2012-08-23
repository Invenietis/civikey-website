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
                return _version ?? ( _version = string.Concat( tRoadMap.Name, '.', RevisionNumber ) );
            }
        }
	}
}