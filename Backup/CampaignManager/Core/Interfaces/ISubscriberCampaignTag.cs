using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CampaignManager.Core.Interfaces
{
    public interface ISubscriberCampaignTag<T>
    {
        int ID { get; set; }
        T SubscriberID { get; set; }
        int CampaignTagID { get; set; }

    }
}
