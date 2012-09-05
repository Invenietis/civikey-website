using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CiviKey.ViewModel
{
    public class CompanyParticipationViewModel
    {
        public int Percentage { get; private set; }
        public string Name { get; private set; }
        public CompanyParticipationViewModel(string companyName, int percentage)
        {
            Percentage = percentage;
            Name = companyName;
        }
    }
}