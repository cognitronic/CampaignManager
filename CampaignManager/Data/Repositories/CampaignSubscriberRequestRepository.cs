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
    public class CampaignSubscriberRequestRepository : BaseRepository<CampaignSubscriberRequest, int>, ICampaignSubscriberRequestRepository
    {
        public IList<CampaignSubscriberRequest> GetByCampaignSubscriberID(Guid campaignSubscriberID)
        {
            return Session.CreateCriteria<CampaignSubscriberRequest>()
                    .Add(Expression.Eq("CampaignSubscriberID", campaignSubscriberID))
                    .List<CampaignSubscriberRequest>();
        }
    }
}
