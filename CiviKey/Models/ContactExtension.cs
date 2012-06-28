using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CiviKey.Models
{
    public partial class tContact
    {
        public string SafeName
        {
            //Must be synchronized with the GetContactIdFromSafeName stored procedure, in order to find the corresponding name.
            get { return Name.Replace( ' ', '-' ).Replace( "'", "" ).ToLowerInvariant();}
        } 
    }
}