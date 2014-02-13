using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core.Data;
using CampaignManager.Core.Domain;

namespace CampaignManager.Core.Interfaces.Data
{
    public interface ISubscriberCampaignTagRepository : IRepository<SubscriberCampaignTag, int>
    {
        //IList<Subscriber> GetSubscribersByCampaignTagID(int campaignTagID);
        //IList<CampaignTag> GetCampaignTagsBySubscriberID(int subscriberID);
        IList<SubscriberCampaignTag> GetByCampaignTagIDSubscriberID(int campaignTagID, int SubscriberID);
    }
}
