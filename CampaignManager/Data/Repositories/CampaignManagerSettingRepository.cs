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
    public class CampaignManagerSettingRepository : BaseRepository<CampaignManagerSetting, int>
    {
        public CampaignManagerSetting GetBySetting(string setting)
        {
            return Session.CreateCriteria<CampaignManagerSetting>()
                    .Add(Expression.Eq("Setting", setting))
                    .UniqueResult<CampaignManagerSetting>();
        }
    }
}
