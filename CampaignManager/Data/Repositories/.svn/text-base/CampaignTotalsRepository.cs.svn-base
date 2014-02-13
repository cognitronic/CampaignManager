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
    public class CampaignTotalsRepository : BaseRepository<CampaignTotals, int>, ICampaignTotalsRepository
    {
        public CampaignTotals GetByCampaignID(int campaignID)
        {
            return Session.CreateCriteria<CampaignTotals>()
                    .Add(Expression.Eq("CampaignID", campaignID))
                    .UniqueResult<CampaignTotals>();
        }
    }
}
