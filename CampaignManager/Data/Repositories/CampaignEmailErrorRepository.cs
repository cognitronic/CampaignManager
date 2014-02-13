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
    public class CampaignEmailErrorRepository : BaseRepository<CampaignEmailError, int>
    {
        public IList<CampaignEmailError> GetByCampaignID(int campaignID)
        {
            return Session.CreateCriteria<CampaignEmailError>()
                .Add(Expression.Eq("CampaignID", campaignID))
                .List<CampaignEmailError>();
        }
    }
}
