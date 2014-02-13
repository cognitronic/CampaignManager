using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Domain;

namespace CampaignManager.Core.Interfaces
{
    public interface ICampaignOptOut
    {
        int ID { get; set; }
        int SubscriberID { get; set; }
        int CampaignID { get; set; }
        DateTime DateUnsubscribed { get; set; }
        Subscriber Subscriber { get; set; }
        Campaign Campaign { get; set; }
    }
}
