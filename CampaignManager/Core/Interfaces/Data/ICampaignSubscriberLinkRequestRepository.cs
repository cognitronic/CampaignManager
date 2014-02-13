using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Domain;
using IdeaSeed.Core.Data;

namespace CampaignManager.Core.Interfaces.Data
{
    public interface ICampaignSubscriberLinkRequestRepository : IRepository<CampaignSubscriberLinkRequest, int>
    {
        IList<CampaignSubscriberLinkRequest> GetByCampaignSubscriberID(Guid campaignSubscriberID);
        IList<CampaignSubscriberLinkRequest> GetByCampaignLinkID(int campaignLinkID);
    }
}
