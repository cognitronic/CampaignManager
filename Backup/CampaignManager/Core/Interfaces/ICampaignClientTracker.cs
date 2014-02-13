using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Domain;

namespace CampaignManager.Core.Interfaces
{
    /// <summary>
    /// The Campaign Client Tracker interface describes the properties of a CampaignClientTracker
    /// </summary>
    public interface ICampaignClientTracker
    {
        int ID { get; set; }
        string IpAddress { get; set; }
        DateTime Date { get; set; }
        string UriStem { get; set; }
        string QueryString { get; set; }
        string UserAgent { get; set; }
        DateTime DateRead { get; set; }
        Guid CampaignClientID { get; set; }
        CampaignSubscriber CampaignClient { get; set; }
    }
}
