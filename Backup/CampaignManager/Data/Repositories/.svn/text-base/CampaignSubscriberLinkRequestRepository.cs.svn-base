using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using IdeaSeed.Core.Data;
using IdeaSeed.Core.Data.NHibernate;
using CampaignManager.Core.Domain;
using CampaignManager.Core.Interfaces.Data;

namespace CampaignManager.Data.Repositories
{
    public class CampaignSubscriberLinkRequestRepository : BaseRepository<CampaignSubscriberLinkRequest, int>, ICampaignSubscriberLinkRequestRepository
    {
        public IList<CampaignSubscriberLinkRequest> GetByCampaignSubscriberID(Guid campaignSubscriberID)
        {
            return Session.CreateCriteria<CampaignSubscriberLinkRequest>()
                    .Add(Expression.Eq("CampaignSubscriberID", campaignSubscriberID))
                    .List<CampaignSubscriberLinkRequest>();
        }

        public IList<CampaignSubscriberLinkRequest> GetByCampaignLinkID(int campaignLinkID)
        {
            return Session.CreateCriteria<CampaignSubscriberLinkRequest>()
                    .Add(Expression.Eq("CampaignLinkID", campaignLinkID))
                    .List<CampaignSubscriberLinkRequest>();
        }
    }
}
