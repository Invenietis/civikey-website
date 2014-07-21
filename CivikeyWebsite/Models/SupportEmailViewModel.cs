using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CK.Mailer;

namespace CivikeyWebsite.Models
{
    public class SupportEmailViewModel : IMailConfigurator<SupportEmailViewModel>
    {
        public SupportEmailViewModel()
        {

        }

        [Required(ErrorMessage = "Veuillez sélectionner une adresse email valide")]
        [EmailAddress(ErrorMessage = "Veuillez sélectionner une adresse email valide")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Veuillez saisir un titre pour votre question")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Veuillez poser une question")]
        public string Body { get; set; }

        #region IMailConfigurator<SupportEmailViewModel> Members

        public void ConfigureMail( SupportEmailViewModel model, MailParams mailParams )
        {
        }

        public string GetSubject( SupportEmailViewModel model )
        {
            return "Support Civikey";
        }

        #endregion
    }
}