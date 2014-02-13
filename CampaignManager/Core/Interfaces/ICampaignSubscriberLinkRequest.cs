using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Domain;

namespace CampaignManager.Core.Interfaces
{
    public interface ICampaignSubscriberLinkRequest
    {
        int ID { get; set; }
        Guid CampaignSubscriberID { get; set; }
        int CampaignLinkID { get; set; }
        string IP { get; set; }
        string Browser { get; set; }
        string UserAgent { get; set; }
        DateTime DateClicked { get; set; }
        string Referrer { get; set; }
        string OperatingSystem { get; set; }
        string HostName { get; set; }
    }
}
