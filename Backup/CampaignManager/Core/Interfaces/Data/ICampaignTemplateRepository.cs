﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IdeaSeed.Core.Data;
using CampaignManager.Core.Domain;

namespace CampaignManager.Core.Interfaces.Data
{
    public interface ICampaignTemplateRepository : IRepository<CampaignTemplate, int>
    {
    }
}
