using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CivikeyWebsite.Models
{
    [Flags]
    public enum KeyboardPostError
    {
        None = 0,
        InvalidForm = 1,
        MissingPicture = 2,
        PictureSize = 3
    }

    public class KeyboardModel
    {
        [Required]
        [StringLength( 30 )]
        public string Name { get; set; }
        
        [Required]
        [StringLength( 165 )]
        public string Description { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Author { get; set; }
    }
}