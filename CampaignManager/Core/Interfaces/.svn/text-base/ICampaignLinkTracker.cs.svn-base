using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Domain;

namespace CampaignManager.Core.Interfaces
{
    public interface ICampaignLinkTracker
    {
        int ID { get; set; }
        Guid CampaignLinkID { get; set; }
        Guid CampaignClientID { get; set; }
        string IpAddress { get; set; }
        DateTime Date { get; set; }
        string UserAgent { get; set; }
        string Browser { get; set; }
        string Referer { get; set; }
        CampaignSubscriber CampaignClient { get; set; }
        CampaignLink CampaignLink { get; set; }
    }
}
