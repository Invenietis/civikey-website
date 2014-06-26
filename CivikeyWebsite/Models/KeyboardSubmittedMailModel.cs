using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CK.Mailer;
namespace CivikeyWebsite.Models
{
    public class KeyboardSubmittedMailModel : IMailConfigurator<KeyboardSubmittedMailModel>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public string Author { get; set; }

        public string Subject { get; set; }

        #region IMailConfigurator<KeyboardSubmittedMailModel> Members

        public void ConfigureMail( KeyboardSubmittedMailModel model, MailParams mailParams )
        {
        }

        public string GetSubject( KeyboardSubmittedMailModel model )
        {
            return Subject;
        }

        #endregion
    }
}