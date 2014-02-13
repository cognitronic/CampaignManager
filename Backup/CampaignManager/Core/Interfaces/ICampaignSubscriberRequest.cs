using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Domain;

namespace CampaignManager.Core.Interfaces
{
    public interface ICampaignSubscriberRequest
    {
        int ID { get; set; }
        Guid CampaignSubscriberID { get; set; }
        string IP { get; set; }
        string Browser { get; set; }
        string UserAgent { get; set; }
        DateTime DateRequested { get; set; }
        string OperatingSystem { get; set; }
        string HostName { get; set; }
    }
}
