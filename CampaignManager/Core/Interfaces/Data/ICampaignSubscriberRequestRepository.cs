using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Domain;
using IdeaSeed.Core.Data;

namespace CampaignManager.Core.Interfaces.Data
{
    public interface ICampaignSubscriberRequestRepository : IRepository<CampaignSubscriberRequest, int>
    {
        IList<CampaignSubscriberRequest> GetByCampaignSubscriberID(Guid campaignSubscriberID);
    }
}
