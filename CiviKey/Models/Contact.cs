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
        [Email]
        [Required]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        [Display(Name = "De : ")]
        public string From { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [DataType(System.ComponentModel.DataAnnotations.DataType.MultilineText)]
        public string Message { get; set; }
    }
}