using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CampaignManager.Core.Interfaces
{
    public interface ICampaignTemplate
    {
        int ID { get; set; }
        string TemplateName { get; set; }
        string Description { get; set; }
        string EmailSubject { get; set; }
        string EmailBody { get; set; }
        int EnteredBy { get; set; }
        int ChangedBy { get; set; }
        DateTime DateCreated { get; set; }
        DateTime LastUpdated { get; set; }
    }
}
