using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Transform;
using IdeaSeed.Core.Data;
using IdeaSeed.Core.Data.NHibernate;
using CampaignManager.Core.Domain;
using CampaignManager.Core.Interfaces.Data;

namespace CampaignManager.Data.Repositories
{
    public class SubscriberCampaignTagRepository : BaseRepository<SubscriberCampaignTag, int>, ISubscriberCampaignTagRepository
    {
        public IList<SubscriberCampaignTag> GetByCampaignTagIDSubscriberID(int campaignTagID, int subscriberID)
        {
            return Session.CreateCriteria<SubscriberCampaignTag>()
                    .Add(Expression.Eq("CampaignTagID", campaignTagID))
                    .Add(Expression.Eq("SubscriberID", subscriberID)).List<SubscriberCampaignTag>();
        }

        public IList<SubscriberCampaignTag> GetByCampaignTagID(int campaignTagID)
        {
            return Session.CreateCriteria<SubscriberCampaignTag>()
                    .Add(Expression.Eq("CampaignTagID", campaignTagID)).List<SubscriberCampaignTag>();
        }

        public IList<SubscriberCampaignTag> GetBySubscriberID(int subscriberID)
        {
            return Session.CreateCriteria<SubscriberCampaignTag>()
                    .Add(Expression.Eq("SubscriberID", subscriberID)).List<SubscriberCampaignTag>();
        }
    }
}
