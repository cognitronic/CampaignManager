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
    public class CampaignSubscriberRepository : BaseRepository<CampaignSubscriber, Guid>, ICampaignSubscriberRepository
    {
        public IList<CampaignSubscriber> GetByCampaignID(int campaignID)
        {
            return Session.CreateCriteria<CampaignSubscriber>()
                    .Add(Expression.Eq("CampaignID", campaignID))
                    .List<CampaignSubscriber>();
        }
    }
}
