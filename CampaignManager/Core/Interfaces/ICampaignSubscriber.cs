using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Domain;

namespace CampaignManager.Core.Interfaces
{
    public interface ICampaignSubscriber
    {
        Guid ID { get; set; }
        int CampaignID { get; set; }
        int SubscriberID { get; set; }
    }
}
