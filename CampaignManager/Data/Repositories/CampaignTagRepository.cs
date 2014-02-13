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
    public class CampaignTagRepository : BaseRepository<CampaignTag, int>, ICampaignTagRepository
    {
        public IList<CampaignTag> GetByIsPublic(bool ispublic)
        {
            return Session.CreateCriteria<CampaignTag>()
                .Add(Expression.Eq("IsPublic", ispublic))
                .List<CampaignTag>();
        }
    }
}
