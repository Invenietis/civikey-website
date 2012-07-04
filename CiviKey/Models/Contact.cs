using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CK.Web.Mvc;

namespace CiviKey.Models
{
    public class Contact
    {
        [Email( ErrorMessage = "L'email est invalide" )]
        [Required( ErrorMessage = "Email est requis" )]
        [DataType( DataType.EmailAddress ), Display( Name = "De : " )]
        public string From { get; set; }

        [Required( ErrorMessage = "Le sujet est requis" ), Display( Name = "Sujet : " )]
        public string Subject { get; set; }

        [Required( ErrorMessage = "Le message est requis" ), DataType( DataType.MultilineText ), Display( Name = "Message : " )]
        public string Message { get; set; }
    }
}