using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CampaignManager.Core.Interfaces;

namespace CampaignManager.Core.Domain
{
    public class CampaignLinksReportHelper : ICampaignLinksReportHelper
    {
        public virtual string LinkText { get; set; }
        public virtual int TotalLinkClicks { get; set; }
    }
}
