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
    public class CampaignForwardToAFriendRepository : BaseRepository<CampaignForwardToAFriend, int>
    {
        public IList<CampaignForwardToAFriend> GetByCampaignID(int campaignID)
        {
            return Session.CreateCriteria<CampaignForwardToAFriend>()
                    .Add(Expression.Eq("CampaignID", campaignID))
                    .List<CampaignForwardToAFriend>();
        }

        public IList<CampaignForwardToAFriend> GetBySubscriberID(int subscriberID)
        {
            return Session.CreateCriteria<CampaignForwardToAFriend>()
                    .Add(Expression.Eq("SubscriberID", subscriberID))
                    .List<CampaignForwardToAFriend>();
        }
    }
}
