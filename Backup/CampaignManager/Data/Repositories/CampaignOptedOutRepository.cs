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
    public class CampaignOptedOutRepository : BaseRepository<CampaignOptOut, int>, ICampaignOptedOutRepository
    {
        public IList<CampaignOptOut> GetByCampaignID(int campaignID)
        {
            return Session.CreateCriteria<CampaignOptOut>()
                    .Add(Expression.Eq("CampaignID", campaignID))
                    .List<CampaignOptOut>();
        }

        public IList<CampaignOptOut> GetBySubscriberID(int subscriberID)
        {
            return Session.CreateCriteria<CampaignOptOut>()
                    .Add(Expression.Eq("SubscriberID", subscriberID))
                    .List<CampaignOptOut>();
        }
    }
}
