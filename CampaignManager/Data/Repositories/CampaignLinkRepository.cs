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
    public class CampaignLinkRepository : BaseRepository<CampaignLink, int>, ICampaignLinkRepository
    {
        public IList<CampaignLink> GetByCampaignID(int campaignID)
        {
            return Session.CreateCriteria<CampaignLink>()
                    .Add(Expression.Eq("CampaignID", campaignID))
                    .List<CampaignLink>();
        }
    }
}
